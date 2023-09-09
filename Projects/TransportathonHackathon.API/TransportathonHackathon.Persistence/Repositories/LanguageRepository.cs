using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class LanguageRepository : EfRepositoryBase<Language, ProjectDbContext>, ILanguageRepository
    {
        public LanguageRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
