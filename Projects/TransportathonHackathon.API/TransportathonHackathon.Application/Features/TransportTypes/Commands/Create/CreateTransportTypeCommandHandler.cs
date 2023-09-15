using AutoMapper;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Create
{
    public class CreateTransportTypeCommandHandler : IRequestHandler<CreateTransportTypeCommand, CreatedTransportTypeResponse>
    {
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly IMapper _mapper;

        public CreateTransportTypeCommandHandler(ITransportTypeRepository transportTypeRepository, IMapper mapper)
        {
            _transportTypeRepository = transportTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreatedTransportTypeResponse> Handle(CreateTransportTypeCommand request, CancellationToken cancellationToken)
        {
            TransportType transportType = _mapper.Map<TransportType>(request);
            await _transportTypeRepository.AddAsync(transportType);

            CreatedTransportTypeResponse response = _mapper.Map<CreatedTransportTypeResponse>(transportType);
            return response;
        }
    }
}
