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
            services.AddTransient<AuthenticationWindow>();
            services.AddTransient<GuestWindow>();
            services.AddTransient<MemberWindow>();
            services.AddTransient<VolunteerWindow>();
            services.AddTransient<AdministratorWindow>();
        });
        
        return host;
    }
}