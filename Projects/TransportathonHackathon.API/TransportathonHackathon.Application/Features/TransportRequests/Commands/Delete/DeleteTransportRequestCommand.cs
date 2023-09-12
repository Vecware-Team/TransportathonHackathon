using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete
{
    public class DeleteTransportRequestCommand : IRequest<DeletedTransportRequestResponse>
    {
        public Guid Id { get; set; }
    }
}
