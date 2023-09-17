using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Features.Translates.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Update
{
    public class UpdateTranslateCommandHandler : IRequestHandler<UpdateTranslateCommand, UpdatedTranslateResponse>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;
        private readonly TranslateBusinessRules _rules;

        public UpdateTranslateCommandHandler(ITranslateRepository translateRepository, IMapper mapper, TranslateBusinessRules rules)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedTranslateResponse> Handle(UpdateTranslateCommand request, CancellationToken cancellationToken)
        {
            Translate? translate = await _translateRepository.GetAsync(e => e.Id == request.Id, include: e => e.Include(e => e.Language));
            if (translate is null)
                throw new NotFoundException("Translate not found");

            translate.LanguageId = request.LanguageId;
            translate.Key = request.Key;
            translate.Value = request.Value;
            translate.UpdatedDate = DateTime.UtcNow;

            await _translateRepository.SaveChangesAsync();

            translate.Language.Translates = null;
            UpdatedTranslateResponse response = _mapper.Map<UpdatedTranslateResponse>(translate);
            return response;
        }
    }
}
