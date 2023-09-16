using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommand : IRequest<CreatedDriverResponse>, ITransactionalRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid CompanyId { get; set; }
    }
}
