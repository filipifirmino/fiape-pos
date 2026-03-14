using Marketplace.Catalog.Application.Configure;
using Marketplace.Catalog.Infrastructure.Configure;
using Marketplace.Catalog.Api.Middlewares;
using Microsoft.OpenApi;

namespace Marketplace.Catalog.Api;

public class Startup
{
    public  IConfiguration _Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });
        //services.AddJwtAuthentication(_Configuration);
        services.AddConfigureInfra();
        services.AddApplicationConfiguration();
        services.AddHttpClient();
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo { Title = "Marketplace Catalog API", Version = "v1" });
        });
        //services.AddDbContext<DataContext>(options =>
        //    options.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketplace Catalog API"));
        }
        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<RequestTimingMiddleware>();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
