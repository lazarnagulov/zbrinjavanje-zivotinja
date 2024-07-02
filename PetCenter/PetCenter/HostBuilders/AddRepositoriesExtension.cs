using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Stores;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Repository;
using PetCenter.WPF.ViewModels;

namespace LangLang.HostBuilders;

public static class AddRepositoriesExtension
{
    public static IHostBuilder AddRepositories(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<IAccountRepository, AccountSqlRepository>();
            services.AddSingleton<IAnimalRepository, AnimalSqlRepository>();
            services.AddSingleton<ICommentRepository, CommentSqlRepository>();
            services.AddSingleton<IOfferRepository, OfferSqlRepository>();
            services.AddSingleton<IPersonRepository, PersonSqlRepository>();
            services.AddSingleton<IPostRepository, PostSqlRepository>();
            services.AddSingleton<IRequestRepository, RequestSqlRepository>();
        });
        
        return host;
    }
}