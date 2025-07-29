using AilosTransferencia.Application.Dtos;
using MediatR;

namespace AilosTransferencia.Application.Members.Commands
{
    public class CreateTransferenciaCommand : IRequest<ServiceResult>
    {
        public int NumeroContaCorrenteDestino { get; set; }
        public decimal Valor { get; set; }
        public string TokenRequisicao { get; set; }
    }
}
