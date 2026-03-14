using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Catalog.Infrastructure.Configure;

public static class ConfigureInfra
{
    private static void AddGateways(this IServiceCollection services)
    {
        
    }
    private static void AddRepositories(this IServiceCollection services)
    {
        
    }
    public static void AddConfigureInfra(this IServiceCollection services)
    {
        services.AddGateways();
        services.AddRepositories();
    }
}
