using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Service;
using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Repository;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels;

namespace PetCenter.HostBuilders;

public static class AddServicesExtension
{
    public static IHostBuilder AddServices(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<IWindowFactory, WindowFactory>();
            services.AddSingleton<ViewModelFactory>();
            services.AddSingleton<LoginService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<PostService>();
            services.AddSingleton<PersonService>();
            services.AddSingleton<AnimalTypeService>();
            services.AddSingleton<NotificationService>();
        });
        
        return host;
    }
}