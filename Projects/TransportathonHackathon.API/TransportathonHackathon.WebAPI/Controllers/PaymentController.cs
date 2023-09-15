using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Requests;
using TransportathonHackathon.Application.Services;

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
        public async Task<IActionResult> Payment([FromBody] PaymentRequest paymentRequest)
        {
            bool result = await _paymentService.Payment(paymentRequest);
            if (result)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
