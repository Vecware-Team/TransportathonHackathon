using MediatR;

namespace TransportathonHackathon.Application.Features.Cars.Queries.GetById
{
    public class GetByIdCarQuery : IRequest<GetByIdCarResponse>
    {
        public Guid VehicleId { get; set; }
    }
}
