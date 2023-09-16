using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules : BaseBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameAndCodeCannotBeDuplicatedWhenInsertingOrUpdating(string globallyName, string code)
        {
            Language? language = await _languageRepository.GetAsync(e => e.GloballyName.ToLower() == globallyName.ToLower() || e.Code.ToLower() == code.ToLower());
            if (language is not null)
                throw new BusinessException("Language already exists");
        }
    }
}
