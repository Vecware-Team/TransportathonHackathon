using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Delete
{
    public class DeleteDriverLicenseCommand : IRequest<DeletedDriverLicenseResponse>, ITransactionalRequest
    {
        public Guid DriverId { get; set; }
    }
}
