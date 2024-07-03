using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.Entity.Infrastructure.Design;
using System.Windows;
using PetCenter.WPF.Views;
using PetCenter.HostBuilders;
using LangLang.HostBuilders;
using PetCenter.Core.Stores;
using PetCenter.WPF.ViewModels;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;

namespace PetCenter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
            => _host = CreateHostBuilder().Build();

        private static IHostBuilder CreateHostBuilder(string[]? args = null)
            => Host.CreateDefaultBuilder(args)
                   .AddServices()
                   .AddViewModels()
                   .AddStores()
                   .AddWindows()
                   .AddRepositories();

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            INavigationService navigationService = _host.Services.GetRequiredService<INavigationService>();
            navigationService.SwitchWindow(WindowType.Authentication);

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            base.OnExit(e);
        }
    }

}
