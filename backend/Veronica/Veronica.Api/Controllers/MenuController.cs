using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veronica.Menu;
using Veronica.Menu.Models;

namespace Veronica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuService _service;

        public MenuController(ILogger<MenuController> logger,
            IMenuService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IList<MenuItem>> Get()
        {
            return await _service.GetMenu();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(MenuItemDto item)
        {
            if (!item.IsValid())
                return BadRequest();
            var model = item.GetModel();
            _service.AddNewItem(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(MenuItemDto item, Guid id)
        {
            if (!item.IsValid())
                return BadRequest();
            var model = item.GetModel();
            _service.UpdateItem(model, id);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _service.RemoveItem(id);
            return Ok();
        }
    }
}