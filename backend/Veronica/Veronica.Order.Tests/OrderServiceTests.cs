using FluentAssertions;
using Veronica.Order.Models;

namespace Veronica.Order.Tests
{
    public class OrderServiceTests : BaseTest
    {
        [Fact]
        public async void PlaceNewOrder_ShouldStoreNewOrder_IfValidOrderIsPassed()
        {
            //ARRANGE
            var service = GetMockOrderService();
            var id = Guid.NewGuid();
            var items = new List<OrderItem>();
            var item = new OrderItem();
            item.Name = "item1";
            item.Id = Guid.NewGuid();
            item.Qty = 15;
            item.Price = 150;
            item.CreatedDate = DateTime.UtcNow;
            item.ModifiedDate = DateTime.UtcNow;
            items.Add(item);
            var order = new OrderModel()
            {
                Amount = 150,
                Qty = 3,
                Id = id,
                Username = "user",
                Items = items,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
            };

            //ACT
            service.PlaceNewOrder(order);

            //ASSERT
            var placedOrder = (await service.Get()).FirstOrDefault(x => x.Id == id);
            placedOrder.Should().NotBeNull();
            placedOrder.Items.FirstOrDefault().Should().NotBeNull();
            placedOrder.Items.First().OrderId.Should().Be(id);
        }
    }
}