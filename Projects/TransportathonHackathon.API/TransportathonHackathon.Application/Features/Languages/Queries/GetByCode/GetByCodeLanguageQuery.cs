using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Queries.GetByCode
{
    public class GetByCodeLanguageQuery : IRequest<GetByCodeLanguageResponse>
    {
        public string Code { get; set; }
    }

    public class GetByCodeLanguageQueryHandler : IRequestHandler<GetByCodeLanguageQuery, GetByCodeLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetByCodeLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<GetByCodeLanguageResponse> Handle(GetByCodeLanguageQuery request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(e => e.Code == request.Code, include: e=>e.Include(e=>e.Translates));
            if (language is null)
                throw new NotFoundException("Language not found");

            language.Translates?.ToList().ForEach(e => e.Language = null);
            GetByCodeLanguageResponse response = _mapper.Map<GetByCodeLanguageResponse>(language);
            return response;
        }
    }
}
