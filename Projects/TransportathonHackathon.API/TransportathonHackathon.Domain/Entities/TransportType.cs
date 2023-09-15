using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class TransportType : Entity<Guid>
    {
        public string Type { get; set; }
        public IEnumerable<TransportRequest>? TransportRequests { get; set; }
    }
}
