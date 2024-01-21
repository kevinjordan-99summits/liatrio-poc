using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;

namespace LiatrioPoC.Core.Services.Katas
{
    public class CreateKataCommand
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IKataRepository _kataRepository;

        public CreateKataCommand(ICategoryRepository categoryRepository, IKataRepository kataRepository)
        {
            _categoryRepository = categoryRepository;
            _kataRepository = kataRepository;
        }

        public Kata? Create(Guid categoryId, string name, string? description)
        {
            var category = _categoryRepository.GetById(categoryId);
            if (category is null)
                return null;

            var kata = new Kata { 
                Id = Guid.NewGuid(),
                CategoryId = categoryId,
                Name = name,
                Description = description
            };

            _kataRepository.Insert(kata);

            return kata;
        }
    }
}
