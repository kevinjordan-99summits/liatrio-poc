using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace LiatrioPoC.Core.Services.Katas.Tests
{
    [TestClass()]
    public class CreateKataCommandTests
    {
        ICategoryRepository _categoryRepository;
        IKataRepository _kataRepository;
        IEnumerable<Category> _categories;

        public CreateKataCommandTests()
        {
            _categories = new List<Category> { new Category { Id = Guid.NewGuid(), Name = "Sub Category" } };

            _categoryRepository = Substitute.For<ICategoryRepository>();
            _categoryRepository.GetAll().Returns(_categories);

            _kataRepository = Substitute.For<IKataRepository>();
        }

        [TestMethod()]
        public void CheckCategoryWhenCreatingKataTest()
        {
            var kata = new CreateKataCommand(_categoryRepository, _kataRepository).Create(Guid.NewGuid(), "Test", "Test Description");

            Assert.IsNull(kata);
        }
    }
}