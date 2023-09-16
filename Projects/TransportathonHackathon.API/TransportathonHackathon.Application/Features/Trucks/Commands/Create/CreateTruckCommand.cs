using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Create
{
    public class CreateTruckCommand : IRequest<CreatedTruckResponse>, ITransactionalRequest
    {
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int Size { get; set; }
    }
}
