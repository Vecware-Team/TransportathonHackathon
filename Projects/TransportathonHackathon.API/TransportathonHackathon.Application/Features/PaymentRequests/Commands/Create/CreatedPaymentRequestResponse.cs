namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create
{
    public class CreatedPaymentRequestResponse
    {
        public Guid TransportRequestId { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
    }
}
