using MediatR;

namespace TransportathonHackathon.Application.Features.Comments.Queries.GetById
{
    public class GetByIdCommentQuery : IRequest<GetByIdCommentResponse>
    {
        public Guid TransportRequestId { get; set; }
    }
}
