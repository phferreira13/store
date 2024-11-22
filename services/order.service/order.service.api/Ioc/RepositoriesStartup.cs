using order.service.domain.Interfaces.Repositories;
using order.service.entityframework.Repositories;

namespace order.service.api.Ioc
{
    public static class RepositoriesStartup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
