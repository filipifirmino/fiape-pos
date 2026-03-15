using Marketplace.Catalog.Domain.Gateways;
using Marketplace.Catalog.Domain.Repositories;
using Marketplace.Catalog.Infrastructure.Context;
using Marketplace.Catalog.Infrastructure.Gateways;
using Marketplace.Catalog.Infrastructure.Repositories;
using Marketplace.Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Catalog.Infrastructure.Configure;

public static class ConfigureInfra
{
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    private static void AddGateways(this IServiceCollection services)
    {
        services.AddScoped<IUserGateway, UserGateway>();
        services.AddScoped<IProductGateway, ProductGateway>();
    }

    public static void AddConfigureInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(options =>
            configuration.GetSection("MongoDB").Bind(options));
        services.AddSingleton<MongoDbContext>();
        services.AddRepositories();
        services.AddGateways();
    }
}
