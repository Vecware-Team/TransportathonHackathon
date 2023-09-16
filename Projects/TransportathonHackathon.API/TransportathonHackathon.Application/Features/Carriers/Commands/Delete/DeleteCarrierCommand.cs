using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Delete
{
    public class DeleteCarrierCommand : IRequest<DeletedCarrierResponse>, ITransactionalRequest
    {
        public Guid EmployeeId { get; set; }
    }
}
