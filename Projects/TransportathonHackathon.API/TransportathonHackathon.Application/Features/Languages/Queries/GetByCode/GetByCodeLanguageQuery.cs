using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Queries.GetByCode
{
    public class GetByCodeLanguageQuery : IRequest<GetByCodeLanguageResponse>
    {
        public string Code { get; set; }
    }
}
