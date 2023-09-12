using MediatR;

namespace TransportathonHackathon.Application.Features.Trucks.Queries.GetById
{
    public class GetByIdTruckQuery : IRequest<GetByIdTruckResponse>
    {
        public Guid VehicleId { get; set; }
    }
}
