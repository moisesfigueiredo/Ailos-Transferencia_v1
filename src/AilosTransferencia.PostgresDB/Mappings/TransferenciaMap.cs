using AilosTransferencia.Domain.Entities;
using AilosTransferencia.PostgresDB.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AilosTransferencia.PostgresDB.Mappings
{
    public class TransferenciaMap : IEntityMap<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.Property(x => x.NumeroContaCorrenteOrigem)
                   .IsRequired();
            builder.Property(x => x.NumeroContaCorrenteDestino)
                  .IsRequired();
            builder.Property(x => x.DataMovimento)
                  .IsRequired();
            builder.Property(x => x.Valor)
                  .IsRequired();
        }
    }
}
