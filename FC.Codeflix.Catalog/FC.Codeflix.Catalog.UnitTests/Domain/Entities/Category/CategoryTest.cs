
using FC.CodeFlix.Catalog.Domain.Exceptions;
using Xunit;
using DomainEntity = FC.CodeFlix.Catalog.Domain.Entities;
using DomainException = FC.CodeFlix.Catalog.Domain.Exceptions;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Entities.Category
{
    public class CategoryTest
    {

        [Fact(DisplayName = nameof(Instantiate))]
        [Trait("Domain", "Category - Aggregates")]
        public void Instantiate()
        {
            //Arrange
            var validData = new
            {
                Name = "category name",
                Description = "category description"
            };

            //Act

            var category = new   DomainEntity.Category (validData.Name, validData.Description);

            var datetimeBefore = DateTime.Now;

            var datetimeAfter = DateTime.Now;

            //Assert

            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
            Assert.NotEqual(Guid.Empty, category.Id);
            Assert.NotEqual(default(DateTime), category.CreatedAt);
            Assert.True(category.CreatedAt < datetimeBefore);
            Assert.True(category.CreatedAt < datetimeAfter);
            Assert.True(category.IsActive);


        }

        [Theory(DisplayName = nameof(InstantiateWIthActiveStatus))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData(true)]
        [InlineData(false)]
        public void InstantiateWIthActiveStatus(bool isActive)
        {
            //Arrange
            var validData = new
            {
                Name = "category name",
                Description = "category description"
            };

            //Act

            var category = new DomainEntity.Category(validData.Name, validData.Description, isActive);

            var datetimeBefore = DateTime.Now;

            var datetimeAfter = DateTime.Now;

            //Assert

            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
            Assert.NotEqual(Guid.Empty, category.Id);
            Assert.NotEqual(default(DateTime), category.CreatedAt);
            Assert.True(category.CreatedAt < datetimeBefore);
            Assert.True(category.CreatedAt < datetimeAfter);
            Assert.Equal(isActive,category.IsActive);


        }




        [Theory(DisplayName = nameof(InstanteErrorWhenNameIsEmpty))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void InstanteErrorWhenNameIsEmpty(string? name)
        {

            Action action = () => new DomainEntity.Category(name!, "description category", true);
            var exception = Assert.Throws<EntityValidationException>(action);

            Assert.Equal("Name should not be empty or null",exception.Message);


        
        }

        [Theory(DisplayName = nameof(InstanteErrorWhenDescrptionIsEmpty))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData(null)]
     
        public void InstanteErrorWhenDescrptionIsEmpty(string? description)
        {

            Action action = () => new DomainEntity.Category("name category",description, true);
            var exception = Assert.Throws<EntityValidationException>(action);

            Assert.Equal("Description should not be null", exception.Message);

        }


        //nome deve ter min 3 char
        //nome deve ter max 255 char
        //descricao deve ter 10k de char



    }
}
