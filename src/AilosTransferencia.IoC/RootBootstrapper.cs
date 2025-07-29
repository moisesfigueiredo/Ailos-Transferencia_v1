using AilosTransferencia.Domain.Abstractions;
using AilosTransferencia.PostgresDB.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AilosTransferencia.IoC
{
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services)
        {
            var assemblyTypes = typeof(RootBootstrapper).Assembly.GetNoAbstractTypes();

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseRepository), assemblyTypes);

            //Repositories postgresDB
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();

            var handlers = AppDomain.CurrentDomain.Load("AilosTransferencia.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));
        }
    }
}