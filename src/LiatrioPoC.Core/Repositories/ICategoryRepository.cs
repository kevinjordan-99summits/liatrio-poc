using LiatrioPoC.Core.Entities;

namespace LiatrioPoC.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(Guid categoryId);
    }
}
