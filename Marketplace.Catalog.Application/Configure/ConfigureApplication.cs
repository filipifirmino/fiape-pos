using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Catalog.Application.Configure;

public static class ConfigureApplication
{
    private static void ConfigureDependences(this IServiceCollection services)
    {

    }
    
    public static void AddApplicationConfiguration(this IServiceCollection services)
    {
        services.ConfigureDependences();
    }    
}
