using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veronica.Menu.Models;

namespace Veronica.Menu.Data
{
    public class MenuItemMappings : IEntityTypeConfiguration<MenuItem>
    {
        public MenuItemMappings()
        {

        }

        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
        }
    }
}
