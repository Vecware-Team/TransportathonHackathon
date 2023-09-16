using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver
{
    public class DeleteDriverCommand : IRequest<DeletedDriverResponse>, ITransactionalRequest
    {
        public Guid EmployeeId { get; set; }
    }
}
