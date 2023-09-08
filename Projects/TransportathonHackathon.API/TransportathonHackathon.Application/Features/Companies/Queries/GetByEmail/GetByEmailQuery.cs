using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetByEmail
{
    public class GetByEmailCompanyQuery : IRequest<GetByEmailCompanyResponse>
    {
        public string Email { get; set; }
    }
}
