using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish
{
    public class FinishTransportRequestCommand : IRequest<FinishedTransportRequestResponse>
    {
        public Guid Id { get; set; }
    }

}
