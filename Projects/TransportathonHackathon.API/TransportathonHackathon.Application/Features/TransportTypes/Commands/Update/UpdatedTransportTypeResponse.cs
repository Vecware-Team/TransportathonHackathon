namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Update
{
    public class UpdatedTransportTypeResponse
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
