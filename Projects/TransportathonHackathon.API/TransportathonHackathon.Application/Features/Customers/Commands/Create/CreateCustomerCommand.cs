using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommand : IRequest<CreatedCustomerResponse>, ITransactionalRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
