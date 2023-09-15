namespace TransportathonHackathon.Infrastructure.Payment.FakePaymentService
{
    public class FakePaymentService : IPaymentService
    {
        public async Task<bool> Payment(PaymentObject paymentObject)
        {
            return true;
        }
    }
}
