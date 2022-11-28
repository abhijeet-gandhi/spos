using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Veronica.Order.Models;

namespace Veronica.Order
{
    public interface IOrderService
    {
        void PlaceNewOrder(OrderModel newOrder);

        Task<IList<OrderModel>> Get();
    }

    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _repository;

        public OrderService(ILogger<OrderService> logger,
            IOrderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public void PlaceNewOrder(OrderModel newOrder)
        {
            _repository.Create(newOrder);
        }

        public async Task<IList<OrderModel>> Get()
        {
            return await _repository.All.ToListAsync();
        }
    }
}