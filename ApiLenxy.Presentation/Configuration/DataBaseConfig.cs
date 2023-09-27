using ApiLenxy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiLenxy.Presentation.Configuration;

public static class DataBaseConfig
{
    public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });
    }

    public static void UseDataBaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
        context.Database.Migrate();
        context.Database.EnsureCreated();
    }
}
