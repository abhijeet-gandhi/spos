using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veronica.Menu.Models;
using Veronica.SharedKernel.Repository;

namespace Veronica.Menu.Data
{
    public class MenuDbContext : BaseContext<MenuDbContext>
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options)
            :base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
