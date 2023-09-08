using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Delete
{
    public class DeleteCompanyCommand : IRequest<DeletedCompanyResponse>
    {
        public Guid Id { get; set; }
    }
}
