using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Veronica.Order.Data;

namespace Veronica.Order.Tests
{
    public abstract class BaseTest
    {
        public OrderRepository GetRepository()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase(DateTime.Now.ToString())
                .Options;
            var dbContext = new OrderDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            var repository = new OrderRepository(dbContext);

            return repository;
        }

        public OrderService GetMockOrderService()
        {
            var repository = GetRepository();
            var logger = NullLogger<OrderService>.Instance;
            var service = new OrderService(logger, repository);
            return service;
        }
    }
}