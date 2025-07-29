using AilosTransferencia.Domain.Abstractions;
using AilosTransferencia.Domain.Entities;
using AilosTransferencia.PostgresDB.Core;

namespace AilosTransferencia.PostgresDB.Repositories
{
    public class TransferenciaRepository : Repository<Transferencia>, ITransferenciaRepository
    {
        public TransferenciaRepository(ApplicationDbContext context) :
            base(context)
        {
        }
    }
}
