using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver;
using TransportathonHackathon.Application.Features.Drivers.Dtos;
using TransportathonHackathon.Application.Features.Drivers.Queries.GetList;
using TransportathonHackathon.Application.Features.Drivers.Responses;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(CreateDriverCommand command)
        {
            CreatedDriverResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDriverCommand command)
        {
            DeletedDriverResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDriverCommand command)
        {
            UpdatedDriverResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]GetListDriverCommand command)
        {
            Paginate<GetListDriverResponse> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
