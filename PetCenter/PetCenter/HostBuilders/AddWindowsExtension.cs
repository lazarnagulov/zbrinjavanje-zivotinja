using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.Views;
using PetCenter.WPF.Views.Administrator;
using PetCenter.WPF.Views.Authentication;
using PetCenter.WPF.Views.Guest;
using PetCenter.WPF.Views.Volunteer;

namespace PetCenter.HostBuilders;

public static class AddWindowsExtension
{
    public static IHostBuilder AddWindows(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<AuthenticationWindow>();
            services.AddSingleton<GuestWindow>();
            services.AddSingleton<MemberWindow>();
            services.AddSingleton<VolunteerWindow>();
            services.AddSingleton<AdministratorWindow>();
        });
        
        return host;
    }
}