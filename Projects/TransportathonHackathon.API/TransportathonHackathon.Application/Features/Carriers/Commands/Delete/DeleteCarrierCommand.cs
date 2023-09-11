using MediatR;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Delete
{
    public class DeleteCarrierCommand : IRequest<DeletedCarrierResponse>
    {
        public Guid EmployeeId { get; set; }
    }
}
