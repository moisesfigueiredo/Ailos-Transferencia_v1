using AilosTransferencia.Application.ExternalService;
using AilosTransferencia.IoC;

namespace AilosTransferencia.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            RootBootstrapper.BootstrapperRegisterServices(services);

            services.AddScoped<ContaCorrenteExternalService>();
            services.AddHttpClient();
        }
    }
}
