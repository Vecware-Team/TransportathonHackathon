using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Create
{
    public class CreateCompanyCommand : IRequest<CreatedCompanyResponse>, ITransactionalRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
    }
}
