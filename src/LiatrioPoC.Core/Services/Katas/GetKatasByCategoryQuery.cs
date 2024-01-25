using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;

namespace LiatrioPoC.Core.Services.Katas
{
    public class GetKatasByCategoryQuery
    {
        private readonly IKataRepository _kataRepository;

        public GetKatasByCategoryQuery(IKataRepository kataRepository)
        {
            _kataRepository = kataRepository;
        }

        public IEnumerable<Kata> Get(Guid categoryId)
        {
            return _kataRepository.GetByCategory(categoryId);
        }
    }
}
