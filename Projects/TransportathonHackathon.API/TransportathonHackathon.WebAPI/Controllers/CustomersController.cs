using Core.Persistence.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Customers.Commands.Create;
using TransportathonHackathon.Application.Features.Customers.Commands.Delete;
using TransportathonHackathon.Application.Features.Customers.Commands.Update;
using TransportathonHackathon.Application.Features.Customers.Queries.GetById;
using TransportathonHackathon.Application.Features.Customers.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            CreatedCustomerResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCustomer([FromQuery] DeleteCustomerCommand command)
        {
            DeletedCustomerResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            UpdatedCustomerResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{AppUserId}")]
        public async Task<IActionResult> GetListCustomer([FromRoute] GetByIdCustomerQuery command)
        {
            GetByIdCustomerResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetListCustomer([FromQuery] GetListCustomerQuery command)
        {
            IPaginate<GetListCustomerResponse> response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
