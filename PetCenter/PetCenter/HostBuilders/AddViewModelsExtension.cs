using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.WPF.ViewModels;

namespace LangLang.HostBuilders;

public static class AddViewModelsExtension
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddScoped<MainViewModel>();
            services.AddScoped<Test1ViewModel>();
            services.AddScoped<Test2ViewModel>();
        });
        
        return host;
    }
}