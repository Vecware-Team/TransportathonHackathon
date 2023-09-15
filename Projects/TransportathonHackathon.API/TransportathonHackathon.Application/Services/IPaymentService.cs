using TransportathonHackathon.Application.Requests;

namespace TransportathonHackathon.Application.Services
{
    public interface IPaymentService
    {
        Task<bool> Payment(PaymentRequest paymentRequest);
    }
}
