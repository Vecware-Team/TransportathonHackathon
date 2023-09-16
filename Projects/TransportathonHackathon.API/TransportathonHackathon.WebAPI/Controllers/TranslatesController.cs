using Core.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Translates.Commands.Create;
using TransportathonHackathon.Application.Features.Translates.Commands.Delete;
using TransportathonHackathon.Application.Features.Translates.Commands.Update;
using TransportathonHackathon.Application.Features.Translates.Queries.GetById;
using TransportathonHackathon.Application.Features.Translates.Queries.GetByKey;
using TransportathonHackathon.Application.Features.Translates.Queries.GetByLanguageCode;
using TransportathonHackathon.Application.Features.Translates.Queries.GetByLanguageCodeAsString;
using TransportathonHackathon.Application.Features.Translates.Queries.GetList;
using TransportathonHackathon.WebAPI.Dtos.Translate;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TranslatesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTranslateDto command)
        {
            CreatedTranslateResponse response = await Mediator.Send(Mapper.Map<CreateTranslateCommand>(command));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteTranslateDto command)
        {
            DeletedTranslateResponse response = await Mediator.Send(Mapper.Map<DeleteTranslateCommand>(command));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTranslateDto command)
        {
            UpdatedTranslateResponse response = await Mediator.Send(Mapper.Map<UpdateTranslateCommand>(command));
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTranslateQuery command)
        {
            GetByIdTranslateResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{Key}")]
        public async Task<IActionResult> GetByKey([FromRoute] GetByKeyTranslateQuery command)
        {
            IList<GetByKeyTranslateResponse> response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{LanguageCode}")]
        public async Task<IActionResult> GetByLanguageCode([FromRoute] GetByLanguageCodeTranslateQuery command)
        {
            IList<GetByLanguageCodeTranslateResponse> response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{LanguageCode}")]
        public async Task<IActionResult> GetByLanguageCodeAsString([FromRoute] GetByLanguageCodeAsStringQuery command)
        {
            string response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListTranslateQuery command)
        {
            IList<GetListTranslateResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
