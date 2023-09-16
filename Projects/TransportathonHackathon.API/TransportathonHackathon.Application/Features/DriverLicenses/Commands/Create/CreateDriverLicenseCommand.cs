using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create
{
    public class CreateDriverLicenseCommand : IRequest<CreatedDriverLicenseResponse>, ITransactionalRequest
    {
        public Guid DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classes { get; set; }
        public bool IsNew { get; set; }
        public DateTime LicenseGetDate { get; set; }
    }
}
