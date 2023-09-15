using AutoMapper;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportTypes.Queries.GetList
{
    public class GetListTransportTypeQueryHandler : IRequestHandler<GetListTransportTypeQuery, List<GetListTransportTypeResponse>>
    {
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly IMapper _mapper;

        public GetListTransportTypeQueryHandler(ITransportTypeRepository transportTypeRepository, IMapper mapper)
        {
            _transportTypeRepository = transportTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListTransportTypeResponse>> Handle(GetListTransportTypeQuery request, CancellationToken cancellationToken)
        {
            IList<TransportType> transportTypes = await _transportTypeRepository.GetListAsync();

            List<GetListTransportTypeResponse> response = _mapper.Map<List<GetListTransportTypeResponse>>(transportTypes.ToList());
            return response;
        }
    }
}
