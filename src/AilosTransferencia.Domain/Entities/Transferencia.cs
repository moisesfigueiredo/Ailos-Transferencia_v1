using AilosTransferencia.Domain.Validation;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AilosTransferencia.Domain.Entities
{
    public class Transferencia : EntityBase
    {
        public int NumeroContaCorrenteOrigem { get; set; }
        public int NumeroContaCorrenteDestino { get; set; }
        public DateTime DataMovimento { get; set; } = DateTime.UtcNow;
        public decimal Valor { get; set; }

        public Transferencia()
        {
                
        }

        public Transferencia(int numeroContaCorrenteOrigem, int numeroContaCorrenteDestino, decimal valor)
        {
            ValidarDominio(numeroContaCorrenteOrigem, numeroContaCorrenteDestino, valor);
        }

        public void ValidarDominio(int numeroContaCorrenteOrigem, int numeroContaCorrenteDestino, decimal valor)
        {
            DomainValidation.When(numeroContaCorrenteOrigem <= 0, "Conta corrente origem não informada.");
            DomainValidation.When(numeroContaCorrenteDestino <= 0, "Conta destino origem não informada.");
            DomainValidation.When(valor <= 0, "Apenas valores positivos são válidos.");

            NumeroContaCorrenteOrigem = numeroContaCorrenteOrigem;
            NumeroContaCorrenteDestino = numeroContaCorrenteDestino;
            Valor = valor;
        }
    }
}
