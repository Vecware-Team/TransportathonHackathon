using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetByLanguageCodeAsString
{
    public class GetByLanguageCodeAsStringQueryHandler : IRequestHandler<GetByLanguageCodeAsStringQuery, string>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;

        public GetByLanguageCodeAsStringQueryHandler(ITranslateRepository translateRepository, IMapper mapper)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(GetByLanguageCodeAsStringQuery request, CancellationToken cancellationToken)
        {
            IList<Translate> translates = await _translateRepository.GetListAsync(e => e.Language.Code == request.LanguageCode, include: e => e.Include(e => e.Language));
            Dictionary<string, string> translatesDictionary = translates.ToDictionary(e => e.Key, e => e.Value);

            return JsonSerializer.Serialize(translatesDictionary);
        }
    }
}
