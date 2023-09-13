using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Companies.Commands.Create;
using TransportathonHackathon.Application.Features.Companies.Commands.Delete;
using TransportathonHackathon.Application.Features.Companies.Commands.Update;
using TransportathonHackathon.Application.Features.Companies.Queries.GetByEmail;
using TransportathonHackathon.Application.Features.Companies.Queries.GetById;
using TransportathonHackathon.Application.Features.Companies.Queries.GetList;
using TransportathonHackathon.Application.Features.Companies.Queries.GetListDynamic;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            CreatedCompanyResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCompanyCommand command)
        {
            DeletedCompanyResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand command)
        {
            UpdatedCompanyResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{AppUserId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCompanyQuery command)
        {
            GetByIdCompanyResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery] GetByEmailCompanyQuery command)
        {
            GetByEmailCompanyResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListCompanyQuery command)
        {
            IPaginate<GetListCompanyResponse> response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetListDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
        {
            GetListDynamicCompanyQuery command = new() { DynamicQuery = dynamicQuery, PageRequest = pageRequest };
            IPaginate<GetListDynamicCompanyResponse> response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
