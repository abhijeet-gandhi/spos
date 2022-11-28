using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veronica.Order.Models;

namespace Veronica.Order.Data.Mappings
{
    internal class OrderMappings : IEntityTypeConfiguration<OrderModel>
    {
        public OrderMappings()
        {
        }

        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired();
            builder.HasMany(x => x.Items)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
        }
    }
}