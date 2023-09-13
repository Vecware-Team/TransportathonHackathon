using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Delete
{
    public class DeletedCommentResponse
    {
        public Guid TransportRequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
        public TransportRequest TransportRequest { get; set; }
    }
}
