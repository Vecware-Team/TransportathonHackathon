using MediatR;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Delete
{
    public class DeleteDriverLicenseCommand : IRequest<DeletedDriverLicenseResponse>
    {
        public Guid DriverId { get; set; }
    }
}
