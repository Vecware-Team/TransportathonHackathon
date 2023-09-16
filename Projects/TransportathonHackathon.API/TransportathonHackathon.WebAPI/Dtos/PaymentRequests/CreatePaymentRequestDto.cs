namespace TransportathonHackathon.WebAPI.Dtos.PaymentRequests
{
    public class CreatePaymentRequestDto
    {
        public Guid TransportRequestId { get; set; }
        public decimal Price { get; set; }
    }
}
