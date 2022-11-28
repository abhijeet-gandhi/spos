using Veronica.Order.Models;
using Veronica.SharedKernel.Repository;

namespace Veronica.Order.Data
{
    public class OrderRepository : EntityRepository<OrderModel>,
        IOrderRepository
    {
        public OrderRepository(OrderDbContext context)
            : base(context)
        {
        }
    }
}