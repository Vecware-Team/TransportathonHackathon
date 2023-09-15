namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete
{
    public class DeletedTransportTypeResponse
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
