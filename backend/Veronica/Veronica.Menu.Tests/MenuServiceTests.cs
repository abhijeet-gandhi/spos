using FluentAssertions;
using Veronica.Menu.Models;

namespace Veronica.Menu.Tests
{
    public class MenuServiceTests : BaseTest
    {
        [Fact]
        public async void AddNewItem_ShouldCreateNewItem_IfValidDataIsPassed()
        {
            //ARRANGE
            var service = GetMockMenuService();
            var id = Guid.NewGuid();
            var model = new MenuItem
            {
                Id = id,
                Name = "Name",
                PicturePath = "Path",
                Price = 150,
                Tax = 15,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
            };

            //ACT
            service.AddNewItem(model);

            //ASSERT
            var insertedModel = (await service.GetMenu()).FirstOrDefault(x => x.Id == id);
            insertedModel.Should().NotBeNull();

            insertedModel.Name.Should().Be(model.Name);
            insertedModel.PicturePath.Should().Be(model.PicturePath);
            insertedModel.Price.Should().Be(model.Price);
            insertedModel.Tax.Should().Be(model.Tax);
            insertedModel.CreatedDate.Should().Be(model.CreatedDate);
            insertedModel.ModifiedDate.Should().Be(model.ModifiedDate);
        }

        [Fact]
        public async void GetMenu_ShouldReturnAllMenuItems_IfPresent()
        {
            //ARRANGE
            var service = GetMockMenuService();
            var id = Guid.NewGuid();
            var model = new MenuItem
            {
                Id = id,
                Name = "Name",
                PicturePath = "Path",
                Price = 150,
                Tax = 15,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
            };
            service.AddNewItem(model);

            //ACT
            var records = await service.GetMenu();

            //ASSERT
            records.Should().NotBeNullOrEmpty();
            var record = records.Where(x => x.Id == id);
            record.Should().NotBeNull();

            records.First().Name.Should().Be(model.Name);
        }
    }
}