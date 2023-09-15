using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Infrastructure.Payment;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Payment([FromBody] PaymentObject paymentObject)
        {
            return Ok(await _paymentService.Payment(paymentObject));
        }
    }
}
