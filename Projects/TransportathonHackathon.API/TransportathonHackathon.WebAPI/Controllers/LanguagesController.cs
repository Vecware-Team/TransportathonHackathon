using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Languages.Commands.Create;
using TransportathonHackathon.Application.Features.Languages.Commands.Delete;
using TransportathonHackathon.Application.Features.Languages.Commands.Update;
using TransportathonHackathon.Application.Features.Languages.Queries.GetByCode;
using TransportathonHackathon.Application.Features.Languages.Queries.GetById;
using TransportathonHackathon.Application.Features.Languages.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage([FromBody] CreateLanguageCommand command)
        {

            CreatedLanguageResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLanguage([FromQuery] DeleteLanguageCommand command)
        {
            DeletedLanguageResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLanguage([FromBody] UpdateLanguageCommand command)
        {
            UpdatedLanguageResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("[Action]/{Code}")]
        public async Task<IActionResult> GetByCodeLanguage([FromRoute] GetByCodeLanguageQuery command)
        {
            GetByCodeLanguageResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdLanguage([FromRoute] GetByIdLanguageQuery command)
        {
            GetByIdLanguageResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetListLanguage([FromQuery] GetListLanguageQuery command)
        {
            List<GetListLanguageResponse> response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}