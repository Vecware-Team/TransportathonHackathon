using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Delete
{
    public class DeleteCompanyCommand : IRequest<DeletedCompanyResponse>, ITransactionalRequest
    {
        public Guid AppUserId { get; set; }
    }
}
