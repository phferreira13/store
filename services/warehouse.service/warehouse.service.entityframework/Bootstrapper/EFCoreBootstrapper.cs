using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
