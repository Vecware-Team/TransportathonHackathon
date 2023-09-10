using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetById
{
    public class GetByIdTranslateQueryHandler : IRequestHandler<GetByIdTranslateQuery, GetByIdTranslateResponse>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;

        public GetByIdTranslateQueryHandler(ITranslateRepository translateRepository, IMapper mapper)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTranslateResponse> Handle(GetByIdTranslateQuery request, CancellationToken cancellationToken)
        {
            Translate? translate = await _translateRepository.GetAsync(e => e.Id == request.Id, include: e => e.Include(e => e.Language));
            if (translate is null)
                throw new NotFoundException("Translate not found");

            translate.Language.Translates = null;

            GetByIdTranslateResponse response = _mapper.Map<GetByIdTranslateResponse>(translate);
            return response;
        }
    }
}
