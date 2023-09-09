using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Queries.GetList
{
    public class GetListLanguageQuery : IRequest<List<GetListLanguageResponse>>
    {
    }
}
