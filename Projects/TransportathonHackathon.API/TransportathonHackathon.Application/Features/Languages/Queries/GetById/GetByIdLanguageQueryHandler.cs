using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Queries.GetById
{
    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdLanguageResponse> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(e => e.Id == request.Id, include: e => e.Include(e => e.Translates), cancellationToken: cancellationToken);
            if (language is null)
                throw new NotFoundException("Language not found");

            language.Translates?.ToList().ForEach(e => e.Language = null);

            GetByIdLanguageResponse response = _mapper.Map<GetByIdLanguageResponse>(language);
            return response;
        }
    }
}
