using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Administrator;
using PetCenter.WPF.ViewModels.Authentication;
using PetCenter.WPF.ViewModels.Guest;
using PetCenter.WPF.ViewModels.Member;
using PetCenter.WPF.ViewModels.Volunteer;

namespace PetCenter.HostBuilders;

public static class AddViewModelsExtension
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddScoped<AuthenticationViewModel>();
            services.AddScoped<GuestViewModel>();
            services.AddScoped<MemberViewModel>();
            services.AddScoped<VolunteerViewModel>();
            services.AddScoped<AdministratorViewModel>();

            
            services.AddScoped<LoginViewModel>();
            services.AddScoped<RegisterViewModel>();
            services.AddTransient<PostListingViewModel>();
            services.AddScoped<CreatePostViewModel>();
            services.AddScoped<AddFirstVolunteerViewModel>();
            services.AddScoped<PetCenterInfoViewModel>();

            services.AddScoped<CreateViewModel<AuthenticationViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<AuthenticationViewModel>);
            services.AddScoped<CreateViewModel<GuestViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<GuestViewModel>);
            services.AddScoped<CreateViewModel<MemberViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<MemberViewModel>);
            services.AddScoped<CreateViewModel<VolunteerViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<VolunteerViewModel>);
            services.AddScoped<CreateViewModel<AdministratorViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<AdministratorViewModel>);

            services.AddScoped<CreateViewModel<LoginViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<LoginViewModel>);
            services.AddScoped<CreateViewModel<RegisterViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<RegisterViewModel>);
            services.AddScoped<CreateViewModel<PostListingViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<PostListingViewModel>);
            services.AddScoped<CreateViewModel<CreatePostViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<CreatePostViewModel>);
            services.AddScoped<CreateViewModel<AddFirstVolunteerViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<AddFirstVolunteerViewModel>);
            services.AddScoped<CreateViewModel<PetCenterInfoViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<PetCenterInfoViewModel>);
        });
        
        return host;
    }
}