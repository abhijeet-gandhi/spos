using Veronica.SharedKernel.Repository;

namespace Veronica.Order.Models
{
    public interface IOrderRepository : IEntityRepository<OrderModel>
    {
    }
}