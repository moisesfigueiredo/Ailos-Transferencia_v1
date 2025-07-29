using AilosTransferencia.Application.Dtos;
using AilosTransferencia.Application.ExternalService;
using AilosTransferencia.Domain.Abstractions;
using AilosTransferencia.Domain.Entities;
using AilosTransferencia.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AilosTransferencia.Application.Members.Commands
{
    public class CreateTransferenciaCommandHandler : IRequestHandler<CreateTransferenciaCommand, ServiceResult>
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        ContaCorrenteExternalService _contaCorrenteService;

        public CreateTransferenciaCommandHandler(ITransferenciaRepository transferenciaRepository, ContaCorrenteExternalService contaCorrenteService = null)
        {
            _transferenciaRepository = transferenciaRepository;
            _contaCorrenteService = contaCorrenteService;
        }

        public async Task<ServiceResult> Handle(CreateTransferenciaCommand request, CancellationToken cancellationToken)
        {
            ServiceResult result = new();

            try
            {
                var token = _contaCorrenteService.ExtrairTokenRequisicao(request.TokenRequisicao);

                if (string.IsNullOrEmpty(token))
                {
                    result.AddError("Erro ao autenticar");
                    return result;
                }

                var numContaCorrenteOrigem = _contaCorrenteService.ExtrairNumeroContaCorrenteOrigem(token);

                if (numContaCorrenteOrigem <= 0)
                {
                    result.AddError("Conta corrente de origem não encontrada.");
                    return result;
                }

                if (numContaCorrenteOrigem == request.NumeroContaCorrenteDestino)
                {
                    result.AddError("As contas devem ser diferentes.");
                    return result;
                }

                var contaCorrenteOrigem = await _contaCorrenteService.GetContaCorrenteCadastradaAtiva(numContaCorrenteOrigem, token);

                if (contaCorrenteOrigem == null || !contaCorrenteOrigem.IsSuccess)
                {
                    result.AddError("Não foi possível obter dados da conta de origem.");
                    return result;
                }

                var contaCorrenteDestino = await _contaCorrenteService.GetContaCorrenteCadastradaAtiva(request.NumeroContaCorrenteDestino, token);

                if (contaCorrenteDestino == null || !contaCorrenteDestino.IsSuccess)
                {
                    result.AddError("Não foi possível obter dados da conta de destino.");
                    return result;
                }

                var resultadoDebitoOrigem = await _contaCorrenteService.MovimentacaoContaCorrente(numContaCorrenteOrigem, request.Valor, "D", token);

                if (resultadoDebitoOrigem == null || !resultadoDebitoOrigem.IsSuccess)
                {
                    result.AddError("Não foi possível debitar o valor da conta de origem.");
                    return result;
                }

                var resultadoCreditoDestino = await _contaCorrenteService.MovimentacaoContaCorrente(request.NumeroContaCorrenteDestino, request.Valor, "C", token);

                if (resultadoCreditoDestino == null || !resultadoCreditoDestino.IsSuccess)
                {
                    result.AddError("Não foi possível creditar o valor na conta de destino.");

                    var resultadoDebitoOrigemEstorno = await _contaCorrenteService.MovimentacaoContaCorrente(numContaCorrenteOrigem, request.Valor, "C", token);

                    if (resultadoDebitoOrigemEstorno == null || !resultadoDebitoOrigemEstorno.IsSuccess)
                    {
                        result.AddError("Não foi possível estornar o débito da conta de origem.");
                    }

                    return result;
                }

                var transferencia = new Transferencia(numContaCorrenteOrigem, request.NumeroContaCorrenteDestino, request.Valor);

                await _transferenciaRepository.Insert(transferencia);
            }
            catch (DomainValidation ex)
            {
                var errosDetail = new ErrorResultDetail(ErrorResultDetail.INVALID_INPUT.Code, ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
                result.AddError(errosDetail);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}