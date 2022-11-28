namespace Veronica.Order.Models
{
    public class OrderDto
    {
        public OrderDto()
        {
            Username = string.Empty;
        }

        public float Amount { get; set; }
        public int Qty { get; set; }
        public string Username { get; set; }
        public OrderItemDto[] Items { get; set; }

        public bool IsValid()
        {
            if (Items.Count() == 0) return false;
            if (Items.Any(x => !x.IsValid())) return false;
            return true;
        }

        public OrderModel GetModel()
        {
            var model = new OrderModel();
            model.Amount = Amount;
            model.Qty = Qty;
            model.Username = Username;
            model.Items = new List<OrderItem>();
            model.Id = Guid.NewGuid();
            foreach (var item in Items)
            {
                model.Items.Add(new OrderItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Qty = item.Qty,
                    Tax = item.Tax,
                    OrderId = model.Id
                });
            }
            return model;
        }
    }

    public class OrderItemDto
    {
        public OrderItemDto()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
        public float Price { get; set; }
        public float Tax { get; set; }
        public int Qty { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            return true;
        }
    }
}