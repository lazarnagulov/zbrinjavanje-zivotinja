using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Service;

namespace PetCenter.HostBuilders;

public static class AddServicesExtension
{
    public static IHostBuilder AddServices(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<LoginService>();
            services.AddSingleton<PostService>();
            services.AddSingleton<AnimalTypeService>();
        });
        
        return host;
    }
}