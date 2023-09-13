using MediatR;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetByLanguageCodeAsString
{
    public class GetByLanguageCodeAsStringQuery : IRequest<string>
    {
        public string LanguageCode { get; set; }
    }
}
