using AilosTransferencia.Domain.Entities;
using AilosTransferencia.Domain.Validation;

namespace AilosTransferencia.Tests.Domain
{
    public class TransferenciaTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties_WhenParametersAreValid()
        {
            // Arrange
            int origem = 123;
            int destino = 456;
            decimal valor = 100.50m;

            // Act
            var transferencia = new Transferencia(origem, destino, valor);

            // Assert
            Assert.Equal(origem, transferencia.NumeroContaCorrenteOrigem);
            Assert.Equal(destino, transferencia.NumeroContaCorrenteDestino);
            Assert.Equal(valor, transferencia.Valor);
        }

        [Theory]
        [InlineData(0, 456, 100.50)]
        [InlineData(-1, 456, 100.50)]
        public void Constructor_ShouldThrowDomainValidation_WhenOrigemInvalida(int origem, int destino, decimal valor)
        {
            // Act & Assert
            var ex = Assert.Throws<DomainValidation>(() => new Transferencia(origem, destino, valor));
            Assert.Equal("Conta corrente origem não informada.", ex.Message);
        }

        [Theory]
        [InlineData(123, 0, 100.50)]
        [InlineData(123, -1, 100.50)]
        public void Constructor_ShouldThrowDomainValidation_WhenDestinoInvalido(int origem, int destino, decimal valor)
        {
            // Act & Assert
            var ex = Assert.Throws<DomainValidation>(() => new Transferencia(origem, destino, valor));
            Assert.Equal("Conta destino origem não informada.", ex.Message);
        }

        [Theory]
        [InlineData(123, 456, 0)]
        [InlineData(123, 456, -10)]
        public void Constructor_ShouldThrowDomainValidation_WhenValorInvalido(int origem, int destino, decimal valor)
        {
            // Act & Assert
            var ex = Assert.Throws<DomainValidation>(() => new Transferencia(origem, destino, valor));
            Assert.Equal("Apenas valores positivos são válidos.", ex.Message);
        }
    }
}