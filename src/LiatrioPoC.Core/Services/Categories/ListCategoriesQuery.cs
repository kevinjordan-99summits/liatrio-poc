using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;

namespace LiatrioPoC.Core.Services.Categories
{
    public class ListCategoriesQuery
    {
        private readonly ICategoryRepository _categoryRepository;

        public ListCategoriesQuery(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> List()
        {
            return _categoryRepository.GetAll();
        }
    }
}
