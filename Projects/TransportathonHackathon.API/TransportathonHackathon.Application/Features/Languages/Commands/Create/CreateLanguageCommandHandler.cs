using AutoMapper;
using MediatR;
using TransportathonHackathon.Application.Features.Languages.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Create
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly LanguageBusinessRules _rules;

        public CreateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules rules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CreatedLanguageResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            await _rules.LanguageNameAndCodeCannotBeDuplicatedWhenInsertingOrUpdating(request.GloballyName, request.Code);

            Language language = _mapper.Map<Language>(request);
            await _languageRepository.AddAsync(language);

            CreatedLanguageResponse response = _mapper.Map<CreatedLanguageResponse>(language);
            return response;
        }
    }
}
