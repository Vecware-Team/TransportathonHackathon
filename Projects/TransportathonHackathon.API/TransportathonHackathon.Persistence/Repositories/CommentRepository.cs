using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class CommentRepository : EfRepositoryBase<Comment, ProjectDbContext>, ICommentRepository
    {
        public CommentRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
