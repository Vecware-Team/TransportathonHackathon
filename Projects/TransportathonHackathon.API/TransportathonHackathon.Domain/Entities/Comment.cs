using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class Comment : Entity
    {
        public Guid TransportRequestId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Point { get; set; }
        public virtual TransportRequest TransportRequest { get; set; }
    }
}
