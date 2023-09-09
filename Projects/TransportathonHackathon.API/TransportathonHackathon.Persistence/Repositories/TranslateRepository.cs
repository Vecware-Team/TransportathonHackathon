using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class TranslateRepository : EfRepositoryBase<Translate, ProjectDbContext>, ITranslateRepository
    {
        public TranslateRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
