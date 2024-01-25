using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;
using System.Runtime.Caching;

namespace LiatrioPoC.InMemoryDb
{
    public class KataRepository : IKataRepository
    {
        private const string _cacheKey = "katas";
        private List<Kata> _seed => new List<Kata>
        {
            // Containers
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("33c0eb81-3acc-4127-ae32-b6b2e9752ff0"), Name = "Install Docker Desktop", Description = "Learn how to install Docker on your local machine." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("33c0eb81-3acc-4127-ae32-b6b2e9752ff0"), Name = "Run a Container", Description = "Learn the basic steps of building an image and running your own container." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("33c0eb81-3acc-4127-ae32-b6b2e9752ff0"), Name = "Explore Docker Hub", Description = "Go to Docker Hub and look at all the different containers that are offered for various products." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("33c0eb81-3acc-4127-ae32-b6b2e9752ff0"), Name = "Muti-Container Apps", Description = "Run and test multiple containers packaged into a single application." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("33c0eb81-3acc-4127-ae32-b6b2e9752ff0"), Name = "Publish an Image", Description = "Learn how to publish and share your images on Docker Hub." },
            // Continuous Integration
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("85f52c16-b6e4-4abc-949a-c136e62a1823"), Name = "Hello World", Description = "Create a hello world workflow using GitHub Actions." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("85f52c16-b6e4-4abc-949a-c136e62a1823"), Name = "Setup a CI Build", Description = "Use triggers to setup a build for every checkin." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("85f52c16-b6e4-4abc-949a-c136e62a1823"), Name = "Run a Unit Test", Description = "Configure unit testing in your CI build." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("85f52c16-b6e4-4abc-949a-c136e62a1823"), Name = "Using Variables", Description = "Explore variables and secrets for parameterizing your actions." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("85f52c16-b6e4-4abc-949a-c136e62a1823"), Name = "Environments", Description = "Create a multi-stage workflow using different environments." },
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("85f52c16-b6e4-4abc-949a-c136e62a1823"), Name = "Re-usable Workflows", Description = "Don't repeat yourself. Create a reusable workflow." },
            // Source Control
            new Kata { Id = Guid.NewGuid(), CategoryId = new Guid("f7a10b46-0c01-466f-b374-74aa7eb6060c"), Name = "Create a Repo", Description = "Create a new git repo in GitHub." }
        };

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
                return _seed;

            return (IEnumerable<Kata>)katas;
        }

        public IEnumerable<Kata> GetByCategory(Guid categoryId)
        {
            return this.GetAll().Where(kata => kata.CategoryId.Equals(categoryId));
        }

        public Kata? GetById(Guid kataId)
        {
            return this.GetAll().FirstOrDefault(kata => kata.Id.Equals(kataId));
        }

        public void Insert(Kata kata)
        {
            var katas = GetAll();
            katas = katas.Append(kata);
            MemoryCache.Default[_cacheKey] = katas;
        }
    }
}
