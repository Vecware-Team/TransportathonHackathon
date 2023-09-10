using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Create
{
    public class CreateTranslateCommandHandler : IRequestHandler<CreateTranslateCommand, CreatedTranslateResponse>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;

        public CreateTranslateCommandHandler(ITranslateRepository translateRepository, IMapper mapper)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
        }

        public async Task<CreatedTranslateResponse> Handle(CreateTranslateCommand request, CancellationToken cancellationToken)
        {
            Translate translate = _mapper.Map<Translate>(request);
            await _translateRepository.AddAsync(translate);
            


            translate = await _translateRepository.GetAsync(e => e.Key == translate.Key, include: e => e.Include(e => e.Language));
            translate.Language.Translates = null;

            CreatedTranslateResponse response = _mapper.Map<CreatedTranslateResponse>(translate);
            return response;
        }
    }
}
