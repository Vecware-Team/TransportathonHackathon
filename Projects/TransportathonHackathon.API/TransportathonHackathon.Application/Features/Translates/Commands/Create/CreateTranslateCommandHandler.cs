using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Features.Translates.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Create
{
    public class CreateTranslateCommandHandler : IRequestHandler<CreateTranslateCommand, CreatedTranslateResponse>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;
        private readonly TranslateBusinessRules _rules;

        public CreateTranslateCommandHandler(ITranslateRepository translateRepository, IMapper mapper, TranslateBusinessRules rules)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CreatedTranslateResponse> Handle(CreateTranslateCommand request, CancellationToken cancellationToken)
        {
            await _rules.TranslateKeyCannotBeDuplicatedForSameLanguageIdWhenInsertingOrUpdating(request.LanguageId, request.Key);
            
            Translate translate = _mapper.Map<Translate>(request);
            await _translateRepository.AddAsync(translate);
            
            translate = await _translateRepository.GetAsync(e => e.Key == translate.Key, include: e => e.Include(e => e.Language));
            translate.Language.Translates = null;

            CreatedTranslateResponse response = _mapper.Map<CreatedTranslateResponse>(translate);
            return response;
        }
    }
}
