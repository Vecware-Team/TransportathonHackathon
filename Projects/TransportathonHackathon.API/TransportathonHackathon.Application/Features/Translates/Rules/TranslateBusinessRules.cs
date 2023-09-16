using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Rules
{
    public class TranslateBusinessRules : BaseBusinessRules
    {
        private readonly ITranslateRepository _translateRepository;

        public TranslateBusinessRules(ITranslateRepository translateRepository)
        {
            _translateRepository = translateRepository;
        }

        public async Task TranslateKeyCannotBeDuplicatedForSameLanguageIdWhenInsertingOrUpdating(Guid languageId, string key)
        {
            Translate? translate = await _translateRepository.GetAsync(e => e.LanguageId == languageId && e.Key == key);
            if (translate is not null)
                throw new BusinessException("Translate already exists for the language");
        }
    }
}
