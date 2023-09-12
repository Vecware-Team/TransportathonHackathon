using MediatR;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetById
{
    public class GetByIdPickupTruckQuery : IRequest<GetByIdPickupTruckResponse>
    {
        public Guid VehicleId { get; set; }
    }
}
