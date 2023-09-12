using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class TransportRequest : Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public bool IsOffice { get; set; }
        public string PlaceSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Company Company { get; set; }
    }
}
