using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Stores;
using PetCenter.WPF.ViewModels;

namespace LangLang.HostBuilders;

public static class AddStoresExtension
{
    public static IHostBuilder AddStores(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<NavigationStore>();
        });
        
        return host;
    }
}