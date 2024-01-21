using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;

namespace LiatrioPoC.InMemoryDb
{
    public class CategoryRepository : ICategoryRepository
    {
        /// <inheritdoc />
        public IEnumerable<Category> GetAll() => new List<Category> { 
            new Category{ Id = new Guid("33c0eb81-3acc-4127-ae32-b6b2e9752ff0"), Name = "Containers" },
            new Category{ Id = new Guid("85f52c16-b6e4-4abc-949a-c136e62a1823"), Name = "Continuous Integration" },
            new Category{ Id = new Guid("f7a10b46-0c01-466f-b374-74aa7eb6060c"), Name = "Source Control" }
        };

        /// <inheritdoc />
        public Category? GetById(Guid categoryId)
        {
            return GetAll().FirstOrDefault(c => c.Id == categoryId);
        }
    }
}
