using warehouse.service.domain.Interfaces.Repositories;
using warehouse.service.domain.Repositories;

namespace warehouse.service.api.Ioc
{
    public static class RepositoriesStartup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IWarehouseRepository, WarehouseRepository>();
            services.AddSingleton<IItemRepository, ItemRepository>();
        }
    }
}
