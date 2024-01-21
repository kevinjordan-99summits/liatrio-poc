using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;

namespace LiatrioPoC.Core.Services.Katas
{
    public class ListKatasQuery
    {
        private readonly IKataRepository _kataRepository;

        public ListKatasQuery(IKataRepository kataRepository)
        {
            _kataRepository = kataRepository;
        }

        public IEnumerable<Kata> List()
        {
            return _kataRepository.GetAll();
        }
    }
}
