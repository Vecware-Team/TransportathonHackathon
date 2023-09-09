using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Queries.GetList
{
    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, List<GetListLanguageResponse>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListLanguageResponse>> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            IList<Language> languages = await _languageRepository.GetListAsync(include: e => e.Include(e => e.Translates));
            languages.ToList().ForEach(language => language.Translates.ToList().ForEach(translate => translate.Language = null));

            List<GetListLanguageResponse> response = _mapper.Map<List<GetListLanguageResponse>>(languages.ToList());
            return response;
        }
    }
}
