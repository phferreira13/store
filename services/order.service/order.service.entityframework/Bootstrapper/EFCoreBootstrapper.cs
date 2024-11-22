using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using order.service.entityframework.Context;

namespace order.service.entityframework.Bootstrapper;

public static class EFCoreBootstrapper
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrderContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"));
        });

        return services;
    }
}
