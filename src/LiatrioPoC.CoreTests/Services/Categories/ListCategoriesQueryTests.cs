using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;
using LiatrioPoC.Core.Services.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace LiatrioPoC.Core.Services.Categoies.Tests
{
    [TestClass()]
    public class ListCategoriesQueryTests
    {
        ICategoryRepository _categoryRepository;
        IEnumerable<Category> _categories;

        public ListCategoriesQueryTests()
        {
            _categories = new List<Category> { new Category { Id = Guid.NewGuid(), Name = "Sub Category" } };

            _categoryRepository = Substitute.For<ICategoryRepository>();
            _categoryRepository.GetAll().Returns(_categories);
        }

        [TestMethod()]
        public void ReturnCategoriesFromRepository()
        {
            var categories = new ListCategoriesQuery(_categoryRepository).List();
            Assert.AreEqual(_categories.First().Id, categories.First().Id);
        }
    }
}
