using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetByKey
{
    public class GetByKeyTranslateQueryHandler : IRequestHandler<GetByKeyTranslateQuery, List<GetByKeyTranslateResponse>>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;

        public GetByKeyTranslateQueryHandler(ITranslateRepository translateRepository, IMapper mapper)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByKeyTranslateResponse>> Handle(GetByKeyTranslateQuery request, CancellationToken cancellationToken)
        {
            IList<Translate> translates = await _translateRepository.GetListAsync(e => e.Key == request.Key, include: e => e.Include(e => e.Language));
            translates.ToList().ForEach(e => e.Language.Translates = null);

            List<GetByKeyTranslateResponse> response = _mapper.Map<List<GetByKeyTranslateResponse>>(translates.ToList());
            return response;
        }
    }
}
