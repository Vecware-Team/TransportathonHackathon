using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Delete
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<DeletedLanguageResponse> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(e => e.Id == request.Id, include: e => e.Include(e => e.Translates), cancellationToken: cancellationToken);
            if (language is null)
                throw new NotFoundException("Language not found");

            language.Translates?.ToList().ForEach(e => e.Language = null);

            await _languageRepository.DeleteAsync(language, true);

            DeletedLanguageResponse response = _mapper.Map<DeletedLanguageResponse>(language);
            return response;
        }
    }
}
