using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Util;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Repository;

namespace PetCenter.HostBuilders;

public static class AddRepositoriesExtension
{
    public static IHostBuilder AddRepositories(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddDbContext<DataContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(GetConnectionString());
            });
            services.AddSingleton<IAccountRepository, AccountSqlRepository>();
            services.AddSingleton<IAnimalRepository, AnimalSqlRepository>();
            services.AddSingleton<ICommentRepository, CommentSqlRepository>();
            services.AddSingleton<IOfferRepository, OfferSqlRepository>();
            services.AddSingleton<IPersonRepository, PersonSqlRepository>();
            services.AddSingleton<IPostRepository, PostSqlRepository>();
            services.AddSingleton<IRequestRepository, RequestSqlRepository>();
            services.AddSingleton<IAnimalTypeRepository, AnimalTypeSqlRepository>();
        });
        
        return host;
    }

    private static string GetConnectionString()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddUserSecrets<App>()
            .Build();
        var databaseCredentials =
            new DatabaseCredentials(
                config["Database:Host"] ?? string.Empty,
                int.Parse(config["Database:Port"] ?? string.Empty),
                config["Database:Username"] ?? string.Empty,
                config["Database:Password"] ?? string.Empty,
                config["Database:DatabaseName"] ?? string.Empty
            );
        return databaseCredentials.ConnectionString;
    }
}