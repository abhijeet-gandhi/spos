using Veronica.SharedKernel.Repository;

namespace Veronica.Menu.Models
{
    public class MenuItem : Entity<Guid>
    {
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }

        public MenuItem()
        {
        }
    }
}