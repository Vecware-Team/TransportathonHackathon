using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Queries.GetById
{
    public class GetByIdLanguageQuery : IRequest<GetByIdLanguageResponse>
    {
        public Guid Id { get; set; }
    }
}
