using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Comments.Queries.GetByCompanyId
{
    public class GetByCompanyIdCommentQuery : IRequest<Paginate<GetByCompanyIdCommentResponse>>
    {
        public Guid CompanyId { get; set; }
        public PageRequest PageRequest { get; set; } = new();
    }
}
