namespace Veronica.Menu.Models
{
    public class MenuItemDto
    {
        public MenuItemDto()
        {
        }

        public string Name { get; set; }
        public string PicturePath { get; set; }
        public float Price { get; set; }
        public float Tax { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            if (string.IsNullOrWhiteSpace(PicturePath)) return false;
            if (Price < 0) return false;
            return true;
        }

        public MenuItem GetModel()
        {
            var model = new MenuItem();
            model.Name = Name;
            model.PicturePath = PicturePath;
            model.Price = Price;
            model.Tax = Tax;
            return model;
        }
    }
}