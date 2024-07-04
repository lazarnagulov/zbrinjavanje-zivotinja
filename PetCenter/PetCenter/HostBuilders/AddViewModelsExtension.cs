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
            services.AddTransient<AuthenticationViewModel>();
            services.AddTransient<GuestViewModel>();
            services.AddTransient<MemberViewModel>();
            services.AddTransient<VolunteerViewModel>();
            services.AddTransient<AdministratorViewModel>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<PostListingViewModel>();
            services.AddScoped<AddVolunteerViewModel>();
            services.AddScoped<PetCenterInfoViewModel>();
            services.AddTransient<CreatePostViewModel>();
            services.AddTransient<OfferListingViewModel>();
            services.AddTransient<NotificationListingViewModel>();
            services.AddTransient<PostReviewViewModel>();

            services.AddTransient<CreateViewModel<AuthenticationViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<AuthenticationViewModel>);
            services.AddTransient<CreateViewModel<GuestViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<GuestViewModel>);
            services.AddTransient<CreateViewModel<MemberViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<MemberViewModel>);
            services.AddTransient<CreateViewModel<VolunteerViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<VolunteerViewModel>);
            services.AddTransient<CreateViewModel<AdministratorViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<AdministratorViewModel>);

            services.AddTransient<CreateViewModel<LoginViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<LoginViewModel>);
            services.AddTransient<CreateViewModel<RegisterViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<RegisterViewModel>);
            services.AddTransient<CreateViewModel<PostListingViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<PostListingViewModel>);
            services.AddTransient<CreateViewModel<CreatePostViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<CreatePostViewModel>);
            services.AddScoped<CreateViewModel<AddVolunteerViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<AddVolunteerViewModel>);
            services.AddScoped<CreateViewModel<PetCenterInfoViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<PetCenterInfoViewModel>);
            services.AddTransient<CreateViewModel<OfferListingViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<OfferListingViewModel>);
            services.AddTransient<CreateViewModel<NotificationListingViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<NotificationListingViewModel>);
            services.AddTransient<CreateViewModel<PostReviewViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<PostReviewViewModel>);
        });
        
        return host;
    }
}