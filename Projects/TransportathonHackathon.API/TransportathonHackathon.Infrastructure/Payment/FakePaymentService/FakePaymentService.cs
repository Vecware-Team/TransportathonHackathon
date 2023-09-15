using TransportathonHackathon.Application.Requests;
using TransportathonHackathon.Application.Services;

namespace TransportathonHackathon.Infrastructure.Payment.FakePaymentService
{
    public class FakePaymentService : IPaymentService
    {
        public async Task<bool> Payment(PaymentRequest paymentObject)
        {
            return true;
        }
    }
}
