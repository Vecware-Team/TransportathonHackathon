using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Comments.Queries.GetList
{
    public class GetListCommentQuery : IRequest<Paginate<GetListCommentResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();

    }
}
