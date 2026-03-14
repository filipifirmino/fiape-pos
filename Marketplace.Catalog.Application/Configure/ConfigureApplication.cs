using Marketplace.Catalog.Application.interfaces;
using Marketplace.Catalog.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Catalog.Application.Configure;

public static class ConfigureApplication
{
    private static void ConfigureDependences(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, JwtTokenService>();
    }
    
    public static void AddApplicationConfiguration(this IServiceCollection services)
    {
        services.ConfigureDependences();
    }    
}
