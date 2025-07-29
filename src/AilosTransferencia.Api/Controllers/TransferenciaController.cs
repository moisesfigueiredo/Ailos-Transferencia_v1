using AilosTransferencia.Application.Members.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AilosTransferencia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransferenciaController(IMediator mediator = null)
        {
            _mediator = mediator;
        }

        [HttpPost("TrasnfereEntreContasMesmaInstituicao")]
        [Authorize]
        public async Task<IResult> TrasnfereEntreContasMesmaInstituicao(int numeroContaCorrenteDestino, decimal valor)
        {
            var query = new CreateTransferenciaCommand
            {
                NumeroContaCorrenteDestino = numeroContaCorrenteDestino,
                Valor = valor,
                TokenRequisicao = Request.Headers["Authorization"].ToString()
            };

            return Results.Ok(await _mediator.Send(query));
        }
    }
}