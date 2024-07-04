using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Stores;

namespace PetCenter.HostBuilders;

public static class AddStoresExtension
{
    public static IHostBuilder AddStores(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<AuthenticationStore>();
        });
        
        return host;
    }
}