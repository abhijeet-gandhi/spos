using Veronica.SharedKernel.Repository;

namespace Veronica.Order.Models
{
    public class OrderItem : Entity<Guid>
    {
        public OrderItem()
        {
        }

        public string Name { get; set; }
        public float Price { get; set; }
        public float Tax { get; set; }
        public int Qty { get; set; }
        public Guid OrderId { get; set; }
        public virtual OrderModel Order { get; set; }
    }
}