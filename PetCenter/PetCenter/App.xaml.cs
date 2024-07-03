﻿using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.Entity.Infrastructure.Design;
using System.Windows;
using PetCenter.WPF.Views;
using PetCenter.HostBuilders;
using LangLang.HostBuilders;
using PetCenter.Core.Stores;
using PetCenter.Domain.Model;
using PetCenter.Repository;
using PetCenter.WPF.ViewModels;

namespace PetCenter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host = CreateHostBuilder().Build();
        private static IHostBuilder CreateHostBuilder(string[]? args = null)
            => Host.CreateDefaultBuilder(args)
                   .AddViewModels()
                   .AddStores()
                   .AddWindows()
                   .AddServices()
                   .AddRepositories();

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            NavigationStore navigationStore = _host.Services.GetRequiredService<NavigationStore>();
            navigationStore.CurrentViewModel = _host.Services.GetRequiredService<PostListingViewModel>();
            window.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            base.OnExit(e);
        }
    }

}
