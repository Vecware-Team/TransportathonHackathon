using MediatR;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Queries.GetById
{
    public class GetByIdDriverLicenseQuery : IRequest<GetByIdDriverLicenseResponse>
    {
        public Guid DriverId { get; set; }
    }
}
