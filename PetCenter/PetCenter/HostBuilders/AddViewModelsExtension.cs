using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Authentication;
using PetCenter.WPF.ViewModels.Member;

namespace LangLang.HostBuilders;

public static class AddViewModelsExtension
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddScoped<AuthenticationViewModel>();
            services.AddScoped<LoginViewModel>();
            services.AddScoped<RegisterViewModel>();
            services.AddScoped<Test1ViewModel>();
            services.AddScoped<Test2ViewModel>();
            services.AddScoped<MemberViewModel>();

            services.AddScoped<CreateViewModel<AuthenticationViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<AuthenticationViewModel>);
            services.AddScoped<CreateViewModel<LoginViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<LoginViewModel>);
            services.AddScoped<CreateViewModel<RegisterViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<RegisterViewModel>);
            services.AddScoped<CreateViewModel<MemberViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<MemberViewModel>);
            services.AddScoped<CreateViewModel<Test1ViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<Test1ViewModel>);
            services.AddScoped<CreateViewModel<Test2ViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<Test2ViewModel>);
        });
        
        return host;
    }
}