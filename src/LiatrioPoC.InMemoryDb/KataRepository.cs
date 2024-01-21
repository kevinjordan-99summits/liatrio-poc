using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;
using System.Runtime.Caching;

namespace LiatrioPoC.InMemoryDb
{
    public class KataRepository : IKataRepository
    {
        private const string _cacheKey = "katas";

        public KataRepository()
        {
        }

        public void Delete(Kata kata)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kata> GetAll()
        {
            var katas = MemoryCache.Default[_cacheKey];

            if (katas is null)
                return new List<Kata>();

            return (IEnumerable<Kata>)katas;
        }

        public IEnumerable<Kata> GetByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Kata GetById(Guid kataId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Kata kata)
        {
            var katas = GetAll();
            katas = katas.Append(kata);
            MemoryCache.Default[_cacheKey] = katas;
        }

        public void Update(Kata kata)
        {
            throw new NotImplementedException();
        }
    }
}
