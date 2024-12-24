using ABCExchange.Services;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ABCExchange
{
    public interface IServiceRegistrar
    {
        void Update(IServiceCollection serviceCollection);
        void Register(IServiceCollection serviceCollection, IConfiguration configuration);
    }

    public class ServiceRegistrar : IServiceRegistrar
    {
        public void Update(IServiceCollection serviceCollection)
        {
            // Implement the Update method if needed
        }

        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHttpClient<IForexService, ForexService>();
            serviceCollection.AddScoped<ITransactionServices, TransanctionServices>(); 
        }
    }
}
