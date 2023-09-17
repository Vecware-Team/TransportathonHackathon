using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Customers.Commands.Create;
using TransportathonHackathon.Application.Features.Customers.Commands.Delete;
using TransportathonHackathon.Application.Features.Customers.Commands.Update;
using TransportathonHackathon.Application.Features.Customers.Queries.GetById;
using TransportathonHackathon.Application.Features.Customers.Queries.GetList;
using TransportathonHackathon.WebAPI.Dtos.Customer;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto command)
        {
            CreatedCustomerResponse response = await Mediator.Send(Mapper.Map<CreateCustomerCommand>(command));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCustomerDto command)
        {
            DeletedCustomerResponse response = await Mediator.Send(Mapper.Map<DeleteCustomerCommand>(command));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto command)
        {
            UpdatedCustomerResponse response = await Mediator.Send(Mapper.Map<UpdateCustomerCommand>(command));
            return Ok(response);
        }

        [HttpGet("{AppUserId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerQuery command)
        {
            GetByIdCustomerResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListCustomerQuery command)
        {
            IPaginate<GetListCustomerResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
