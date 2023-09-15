namespace TransportathonHackathon.Infrastructure.Payment
{
    public interface IPaymentService
    {
        Task<bool> Payment(PaymentObject paymentObject);
    }

    public class PaymentObject
    {
        public string CardNumber { get; set; }
        public string FullName{ get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int CVV { get; set; }
        public decimal Price { get; set; }
    }
}
