using Microsoft.EntityFrameworkCore;
using Veronica.Menu.Models;
using Veronica.SharedKernel.Repository;

namespace Veronica.Menu.Data
{
    public class MenuItemRepository : EntityRepository<MenuItem>,
        IMenuItemRepository
    {
        public MenuItemRepository(MenuDbContext context)
            : base(context)
        {

        }
    }
}