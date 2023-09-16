using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<UpdatedCustomerResponse>, ITransactionalRequest
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
