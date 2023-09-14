using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Messages.Queries.GetByReceiverAndSender;
using TransportathonHackathon.Application.Features.Messages.Queries.GetByUser;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetBySenderAndReceiver([FromQuery] GetByReceiverAndSenderMessageQuery command)
        {
            IPaginate<GetByReceiverAndSenderMessageResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetByUser([FromQuery] GetByUserQuery command)
        {
            IList<GetByUserResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
