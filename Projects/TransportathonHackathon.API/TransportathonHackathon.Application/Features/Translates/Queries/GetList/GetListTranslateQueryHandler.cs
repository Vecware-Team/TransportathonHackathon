using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetList
{
    public class GetListTranslateQueryHandler : IRequestHandler<GetListTranslateQuery, List<GetListTranslateResponse>>
    {
        private readonly ITranslateRepository _translateRepository;
        private readonly IMapper _mapper;

        public GetListTranslateQueryHandler(ITranslateRepository translateRepository, IMapper mapper)
        {
            _translateRepository = translateRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListTranslateResponse>> Handle(GetListTranslateQuery request, CancellationToken cancellationToken)
        {
            IList<Translate> translates = await _translateRepository.GetListAsync(include: e => e.Include(e => e.Language));
            translates.ToList().ForEach(e => e.Language.Translates = null);

            List<GetListTranslateResponse> response = _mapper.Map<List<GetListTranslateResponse>>(translates.ToList());
            return response;
        }
    }
}
