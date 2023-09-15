namespace TransportathonHackathon.Application.Features.TransportTypes.Queries.GetList
{
    public class GetListTransportTypeResponse
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
