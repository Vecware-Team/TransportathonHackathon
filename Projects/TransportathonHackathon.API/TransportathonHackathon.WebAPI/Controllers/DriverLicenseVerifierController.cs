using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Requests;
using TransportathonHackathon.Application.Services;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriverLicenseVerifierController : ControllerBase
    {
        private readonly IDriverLicenseVerifierService _driverLicenseVerifierService;

        public DriverLicenseVerifierController(IDriverLicenseVerifierService driverLicenseVerifierService)
        {
            _driverLicenseVerifierService = driverLicenseVerifierService;
        }

        [HttpPost]
        public async Task<IActionResult> Verify([FromBody] DriverLicenseRequest driverLicenseRequest)
        {
            bool result = await _driverLicenseVerifierService.Verify(driverLicenseRequest);
            if (result)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
