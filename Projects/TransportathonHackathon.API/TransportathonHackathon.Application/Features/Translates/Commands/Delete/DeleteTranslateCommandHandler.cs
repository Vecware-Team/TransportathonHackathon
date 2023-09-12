using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Delete
{
    public class DeleteTranslateCommandHandler : IRequestHandler<DeleteTranslateCommand, DeletedTranslateResponse>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;

        public DeleteTranslateCommandHandler(ITranslateRepository translateRepository, IMapper mapper)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTranslateResponse> Handle(DeleteTranslateCommand request, CancellationToken cancellationToken)
        {
            Translate? translate = await _translateRepository.GetAsync(e => e.Id == request.Id, include: e => e.Include(e => e.Language));
            if (translate is null)
                throw new NotFoundException("Translate not found");

            Language language = _mapper.Map<Language>(translate.Language);
            await _translateRepository.DeleteAsync(translate, true);

            translate.Language = language;
            language.Translates = null;
            DeletedTranslateResponse response = _mapper.Map<DeletedTranslateResponse>(translate);
            return response;
        }
    }
}
