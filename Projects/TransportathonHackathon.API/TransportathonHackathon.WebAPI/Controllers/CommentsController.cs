using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Comments.Commands.Create;
using TransportathonHackathon.Application.Features.Comments.Commands.Delete;
using TransportathonHackathon.Application.Features.Comments.Commands.Update;
using TransportathonHackathon.Application.Features.Comments.Queries.GetByCompanyId;
using TransportathonHackathon.Application.Features.Comments.Queries.GetById;
using TransportathonHackathon.Application.Features.Comments.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentCommand command)
        {
            CreatedCommentResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCommentCommand command)
        {
            DeletedCommentResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentCommand command)
        {
            UpdatedCommentResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{TransportRequestId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCommentQuery command)
        {
            GetByIdCommentResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListCommentQuery command)
        {
            IPaginate<GetListCommentResponse> response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetByCompanyId([FromQuery] GetByCompanyIdCommentQuery command)
        {
            IPaginate<GetByCompanyIdCommentResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
