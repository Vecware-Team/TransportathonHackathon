namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Create
{
    public class CreatedTransportTypeResponse
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
