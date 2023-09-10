using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetByLanguageCode
{
    public class GetByLanguageCodeTranslateQueryHandler : IRequestHandler<GetByLanguageCodeTranslateQuery, List<GetByLanguageCodeTranslateResponse>>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;

        public GetByLanguageCodeTranslateQueryHandler(ITranslateRepository translateRepository, IMapper mapper)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByLanguageCodeTranslateResponse>> Handle(GetByLanguageCodeTranslateQuery request, CancellationToken cancellationToken)
        {
            IList<Translate> translates = await _translateRepository.GetListAsync(e => e.Language.Code == request.LanguageCode, include: e => e.Include(e => e.Language));
            translates.ToList().ForEach(e => e.Language.Translates = null);

            List<GetByLanguageCodeTranslateResponse> response = _mapper.Map<List<GetByLanguageCodeTranslateResponse>>(translates.ToList());
            return response;
        }
    }
}
