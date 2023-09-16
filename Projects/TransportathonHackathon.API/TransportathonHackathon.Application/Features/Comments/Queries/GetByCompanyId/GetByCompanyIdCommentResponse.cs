using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Queries.GetByCompanyId
{
    public class GetByCompanyIdCommentResponse
    {
        public Guid TransportRequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
        public TransportRequest TransportRequest { get; set; }
    }
}
