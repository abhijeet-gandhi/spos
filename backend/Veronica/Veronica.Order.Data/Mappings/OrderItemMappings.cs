using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veronica.Order.Models;

namespace Veronica.Order.Data.Mappings
{
    public class OrderItemMappings : IEntityTypeConfiguration<OrderItem>
    {
        public OrderItemMappings()
        {
        }

        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Order).WithMany(x => x.Items);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
        }
    }
}