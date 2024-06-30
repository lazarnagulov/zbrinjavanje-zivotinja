using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Windows;

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
            => Host.CreateDefaultBuilder(args);

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            Window window = _host.Services.GetRequiredService<MainWindow>();
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
