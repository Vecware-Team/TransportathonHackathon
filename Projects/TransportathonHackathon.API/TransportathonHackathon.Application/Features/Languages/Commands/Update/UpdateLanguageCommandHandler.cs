using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Features.Languages.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Update
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly LanguageBusinessRules _rules;

        public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules rules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedLanguageResponse> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            await _rules.LanguageNameAndCodeCannotBeDuplicatedWhenInsertingOrUpdating(request.GloballyName, request.Code);

            Language languageToUpdate = _mapper.Map<Language>(request);

            Language? language = await _languageRepository.GetAsync(
                e => e.Id == languageToUpdate.Id,
                include: e => e.Include(e => e.Translates),
                cancellationToken: cancellationToken
            );

            if (language is null)
                throw new NotFoundException("Language not found");


            language.Code = languageToUpdate.Code;
            language.LocallyName = languageToUpdate.LocallyName;
            language.GloballyName = languageToUpdate.GloballyName;
            language.UpdatedDate = DateTime.UtcNow;

            await _languageRepository.SaveChangesAsync();

            language.Translates?.ToList().ForEach(e => e.Language = null);
            UpdatedLanguageResponse response = _mapper.Map<UpdatedLanguageResponse>(language);
            return response;
        }
    }
}
