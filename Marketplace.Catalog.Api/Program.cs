
using Marketplace.Catalog.Api;

namespace Marketplace.Catalog.Api;
public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(WebBuilder => WebBuilder.UseStartup<Startup>());
}