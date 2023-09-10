using MediatR;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetByLanguageCode
{
    public class GetByLanguageCodeTranslateQuery : IRequest<List<GetByLanguageCodeTranslateResponse>>
    {
        public string LanguageCode { get; set; }
    }
}
