using MediatR;

namespace TransportathonHackathon.Application.Features.Vehicles.Queries.GetByCompanyIdVehicle
{
    public class GetByCompanyIdVehicleQuery : IRequest<List<GetByCompanyIdVehicleResponse>>
    {
        public Guid CompanyId { get; set; }
    }
}
