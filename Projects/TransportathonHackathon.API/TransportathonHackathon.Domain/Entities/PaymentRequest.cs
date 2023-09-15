using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class PaymentRequest : Entity
    {
        public Guid TransportRequestId { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }

        public virtual TransportRequest TransportRequest { get; set; }
    }
}
