using AilosTransferencia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AilosTransferencia.PostgresDB.Core
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : EntityBase
    {
    }
}
