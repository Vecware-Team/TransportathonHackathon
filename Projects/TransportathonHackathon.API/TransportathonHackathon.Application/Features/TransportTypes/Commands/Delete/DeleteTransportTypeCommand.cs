using MediatR;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete
{
    public class DeleteTransportTypeCommand : IRequest<DeletedTransportTypeResponse>
    {
        public Guid Id { get; set; }
    }
}
