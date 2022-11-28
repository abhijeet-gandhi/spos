using Microsoft.EntityFrameworkCore;
using Veronica.Order.Data.Mappings;
using Veronica.Order.Models;
using Veronica.SharedKernel.Repository;

namespace Veronica.Order.Data
{
    public class OrderDbContext : BaseContext<OrderDbContext>
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
             : base(options)
        {
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new OrderItemMappings().Configure(modelBuilder.Entity<OrderItem>());
            new OrderMappings().Configure(modelBuilder.Entity<OrderModel>());
            base.OnModelCreating(modelBuilder);
        }
    }
}