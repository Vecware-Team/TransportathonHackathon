using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Commands.Create
{
    public class CreatePickupTruckCommand : IRequest<CreatedPickupTruckResponse>, ITransactionalRequest
    {
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int Size { get; set; }
    }
}
