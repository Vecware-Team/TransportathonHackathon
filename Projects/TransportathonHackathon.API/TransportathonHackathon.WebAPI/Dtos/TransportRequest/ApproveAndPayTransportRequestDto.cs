namespace TransportathonHackathon.WebAPI.Dtos.TransportRequest
{
    public class ApproveAndPayTransportRequestDto
    {
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public decimal Price { get; set; }
    }
}
