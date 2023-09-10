using MediatR;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetByKey
{
    public class GetByKeyTranslateQuery : IRequest<List<GetByKeyTranslateResponse>>
    {
        public string Key { get; set; }
    }
}
