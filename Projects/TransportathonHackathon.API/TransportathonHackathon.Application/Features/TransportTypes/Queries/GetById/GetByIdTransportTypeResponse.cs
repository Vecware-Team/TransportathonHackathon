namespace TransportathonHackathon.Application.Features.TransportTypes.Queries.GetById
{
    public class GetByIdTransportTypeResponse
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
