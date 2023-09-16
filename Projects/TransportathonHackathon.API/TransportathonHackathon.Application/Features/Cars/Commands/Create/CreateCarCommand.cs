using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Create
{
    public class CreateCarCommand : IRequest<CreatedCarResponse>, ITransactionalRequest
    {
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
    }
}
