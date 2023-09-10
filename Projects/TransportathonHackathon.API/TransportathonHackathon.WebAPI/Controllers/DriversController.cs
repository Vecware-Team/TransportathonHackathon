using Core.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Application.Features.Drivers.Dtos;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(CreateDriverCommand command)
        {
            CreatedDriverDto result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
