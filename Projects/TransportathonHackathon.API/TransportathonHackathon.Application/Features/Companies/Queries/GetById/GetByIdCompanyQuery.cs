using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetById
{
    public class GetByIdCompanyQuery : IRequest<GetByIdCompanyResponse>
    {
        public Guid AppUserId { get; set; }
    }
}
