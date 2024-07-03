﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.Views;
using PetCenter.WPF.Views.Authentication;

namespace PetCenter.HostBuilders;

public static class AddWindowsExtension
{
    public static IHostBuilder AddWindows(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<AuthenticationWindow>();
            services.AddSingleton<MemberWindow>();
        });
        
        return host;
    }
}