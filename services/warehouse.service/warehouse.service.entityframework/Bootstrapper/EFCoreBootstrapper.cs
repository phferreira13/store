using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using warehouse.service.entityframework.Context;

namespace warehouse.service.entityframework.Bootstrapper;

public static class EFCoreBootstrapper
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WarehouseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"));            
        });

        return services;
    }

    public static void ApplyMigration(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WarehouseContext>();
        context.Database.Migrate();
    }
}
