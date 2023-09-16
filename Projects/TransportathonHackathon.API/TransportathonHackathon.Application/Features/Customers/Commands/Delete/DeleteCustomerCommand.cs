using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<DeletedCustomerResponse>, ITransactionalRequest
    {
        public Guid AppUserId { get; set; }
    }
}
