using LiatrioPoC.Core.Entities;

namespace LiatrioPoC.Core.Repositories
{
    public interface IKataRepository
    {
        IEnumerable<Kata> GetAll();
        
        IEnumerable<Kata> GetByCategory(Guid categoryId);
        
        Kata? GetById(Guid kataId);
        
        void Insert(Kata kata);

        void Update(Kata kata);

        void Delete(Kata kata);
    }

}
