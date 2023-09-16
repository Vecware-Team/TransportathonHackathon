using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Update
{
    public class UpdateCompanyCommand : IRequest<UpdatedCompanyResponse>, ITransactionalRequest
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}
