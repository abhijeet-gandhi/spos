using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Veronica.Menu.Data;

namespace Veronica.Menu.Tests
{
    public abstract class BaseTest
    {
        public MenuItemRepository GetRepository()
        {
            var options = new DbContextOptionsBuilder<MenuDbContext>()
                .UseInMemoryDatabase(DateTime.Now.ToString())
                .Options;
            var dbContext = new MenuDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            var repository = new MenuItemRepository(dbContext);

            return repository;
        }

        public MenuService GetMockMenuService()
        {
            var repository = GetRepository();
            var logger = NullLogger<MenuService>.Instance;
            var service = new MenuService(logger, repository);
            return service;
        }
    }
}