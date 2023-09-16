using TransportathonHackathon.Application.Requests;

namespace TransportathonHackathon.WebAPI.Dtos.PaymentRequests
{
    public class PayPaymentRequestDto
    {
        public Guid TransportRequestId { get; set; }
        public PaymentRequest PaymentRequest { get; set; }
    }
}
