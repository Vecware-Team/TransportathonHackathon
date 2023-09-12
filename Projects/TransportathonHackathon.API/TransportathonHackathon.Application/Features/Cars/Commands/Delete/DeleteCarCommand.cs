using MediatR;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommand : IRequest<DeletedCarResponse>
    {
        public Guid VehicleId { get; set; }
    }
}
