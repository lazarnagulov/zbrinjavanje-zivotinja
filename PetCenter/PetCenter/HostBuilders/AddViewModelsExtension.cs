using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels;

namespace LangLang.HostBuilders;

public static class AddViewModelsExtension
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddScoped<LoginViewModel>();
            services.AddScoped<Test1ViewModel>();
            services.AddScoped<Test2ViewModel>();
            services.AddScoped<MemberViewModel>();

            services.AddScoped<CreateViewModel<LoginViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<LoginViewModel>
            );
            services.AddScoped<CreateViewModel<MemberViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<MemberViewModel>
            );
            services.AddScoped<CreateViewModel<Test1ViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<Test1ViewModel>
            );
            services.AddScoped<CreateViewModel<Test2ViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<Test2ViewModel>
            );
        });
        
        return host;
    }
}