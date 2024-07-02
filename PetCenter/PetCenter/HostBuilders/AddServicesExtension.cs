using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Service;
using PetCenter.Core.Stores;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Repository;
using PetCenter.WPF.ViewModels;

namespace LangLang.HostBuilders;

public static class AddServicesExtension
{
    public static IHostBuilder AddServices(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<LoginService>();
            services.AddSingleton<PostService>();
        });
        
        return host;
    }
}