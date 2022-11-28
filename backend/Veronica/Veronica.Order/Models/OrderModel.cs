using Veronica.SharedKernel.Repository;

namespace Veronica.Order.Models
{
    public class OrderModel : Entity<Guid>
    {
        public OrderModel()
        {
            Username = string.Empty;
        }

        public string Username { get; set; }
        public float Amount { get; set; }
        public int Qty { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}