using MediatR;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver
{
    public class DeleteDriverCommand : IRequest<DeletedDriverResponse>
    {
        public Guid EmployeeId { get; set; }
    }
}
