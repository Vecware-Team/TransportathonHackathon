namespace TransportathonHackathon.WebAPI.Dtos.PaymentRequests
{
    public class UpdatePaymentRequestDto
    {
        public Guid TransportRequestId { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
    }
}
