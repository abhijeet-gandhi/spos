using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Veronica.Menu.Models;

namespace Veronica.Menu
{
    public interface IMenuService
    {
        void AddNewItem(MenuItem item);

        void UpdateItem(MenuItem item, Guid id);

        void RemoveItem(Guid id);

        Task<IList<MenuItem>> GetMenu();
    }

    public class MenuService : IMenuService
    {
        private readonly ILogger<MenuService> _logger;
        private readonly IMenuItemRepository _repository;

        public MenuService(ILogger<MenuService> logger,
            IMenuItemRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IList<MenuItem>> GetMenu()
        {
            return await _repository.All.ToListAsync();
        }

        public void AddNewItem(MenuItem item)
        {
            _repository.Create(item);
        }

        public void UpdateItem(MenuItem item, Guid id)
        {
            var existingItem = _repository.All.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Price = item.Price;
                existingItem.PicturePath = item.PicturePath;
                existingItem.ModifiedDate = DateTime.Now;
            }
        }

        public void RemoveItem(Guid id)
        {
            var item = _repository.All.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _repository.Delete(item);
            }
        }
    }
}