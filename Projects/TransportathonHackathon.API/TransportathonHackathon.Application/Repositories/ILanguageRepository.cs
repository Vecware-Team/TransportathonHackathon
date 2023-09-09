using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface ILanguageRepository : IAsyncRepository<Language>, IRepository<Language>
    {
    }
}
