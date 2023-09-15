namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Create
{
    public class CreatedTransportRequestResponse
    {
        public Guid Id { get; set; }
        public Guid TransportTypeId { get; set; }
        public string TransportType { get; set; }
        public bool IsPaid { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CompanyName { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public bool ApprovedByCompany { get; set; }
        public bool IsFinished { get; set; }
        public string PlaceSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
