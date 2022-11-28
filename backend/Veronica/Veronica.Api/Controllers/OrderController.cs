using Microsoft.AspNetCore.Mvc;
using Veronica.Order;
using Veronica.Order.Models;

namespace Veronica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _service;

        public OrderController(ILogger<OrderController> logger,
            IOrderService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IList<OrderModel>> Get()
        {
            return await _service.Get();
        }

        [HttpPost]
        public IActionResult Create(OrderDto item)
        {
            if (!item.IsValid())
                return BadRequest();
            var order = item.GetModel();
            item.Username = HttpContext.User.Identity.Name;
            _service.PlaceNewOrder(order);
            return Ok();
        }
    }
}