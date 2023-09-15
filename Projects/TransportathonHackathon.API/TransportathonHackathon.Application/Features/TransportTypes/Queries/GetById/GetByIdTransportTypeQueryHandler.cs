using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportTypes.Queries.GetById
{
    public class GetByIdTransportTypeQueryHandler : IRequestHandler<GetByIdTransportTypeQuery, GetByIdTransportTypeResponse>
    {
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly IMapper _mapper;

        public GetByIdTransportTypeQueryHandler(ITransportTypeRepository transportTypeRepository, IMapper mapper)
        {
            _transportTypeRepository = transportTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTransportTypeResponse> Handle(GetByIdTransportTypeQuery request, CancellationToken cancellationToken)
        {
            TransportType? transportType = await _transportTypeRepository.GetAsync(e => e.Id == request.Id);
            if (transportType is null)
                throw new NotFoundException("Transport type not found");

            GetByIdTransportTypeResponse response = _mapper.Map<GetByIdTransportTypeResponse>(transportType);
            return response;
        }
    }
}
