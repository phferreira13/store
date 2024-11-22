using Microsoft.EntityFrameworkCore;
using order.service.domain.Models;

namespace order.service.entityframework.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Customer).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.Status).IsRequired();

                entity.OwnsMany(e => e.ItemList.Items, itemList =>
                {
                    itemList.HasKey(i => i.Id);
                    itemList.Property(i => i.Quantity).IsRequired();
                    itemList.Property(i => i.AddedAt).IsRequired();
                    itemList.HasOne(i => i.Item)
                        .WithMany()
                        .HasForeignKey(i => i.ItemId);
                });

                entity.OwnsMany(e => e.StatusHistory.History, statusHistory =>
                {
                    statusHistory.HasKey(s => s.Id);
                    statusHistory.Property(s => s.Status).IsRequired();
                    statusHistory.Property(s => s.CreatedAt).IsRequired();
                });
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt);

                entity.OwnsMany(e => e.History, history =>
                {
                    history.HasKey(h => h.Id);
                    history.Property(h => h.Name).IsRequired();
                    history.Property(h => h.Price).IsRequired();
                    history.Property(h => h.Description).IsRequired();
                    history.Property(h => h.UpdatedAt).IsRequired();
                });
            });
        }
    }
}
