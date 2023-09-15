using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class TransportRequest : Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid TransportTypeId { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public string PlaceSize { get; set; }
        public bool ApprovedByCompany { get; set; }
        public bool IsFinished { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Company Company { get; set; }
        public virtual TransportType TransportType { get; set; }
        public virtual Comment? Comment { get; set; }
        public virtual PaymentRequest? PaymentRequest { get; set; }
    }
}
