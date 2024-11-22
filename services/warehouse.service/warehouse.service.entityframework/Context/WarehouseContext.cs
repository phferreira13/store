using Microsoft.EntityFrameworkCore;
using warehouse.service.domain.Models;

namespace warehouse.service.entityframework.Context;
public class WarehouseContext : DbContext
{
    public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WarehouseContext).Assembly);
    }
}
