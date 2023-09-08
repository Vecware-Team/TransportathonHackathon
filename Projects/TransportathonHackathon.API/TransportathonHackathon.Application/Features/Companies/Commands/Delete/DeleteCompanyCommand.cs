using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Delete
{
    public class DeleteCompanyCommand : IRequest<DeletedCompanyResponse>
    {
        public Guid AppUserId { get; set; }
    }
}
