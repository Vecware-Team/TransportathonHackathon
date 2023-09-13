using MediatR;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<DeletedCommentResponse>
    {
        public Guid TransportRequestId { get; set; }
    }
}
