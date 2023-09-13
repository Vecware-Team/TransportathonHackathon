using MediatR;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Update
{
    public class UpdateCommentCommand : IRequest<UpdatedCommentResponse>
    {
        public Guid TransportRequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
    }
}
