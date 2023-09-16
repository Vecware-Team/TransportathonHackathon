using AutoMapper;
using MediatR;
using TransportathonHackathon.Application.Features.TransportTypes.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Create
{
    public class CreateTransportTypeCommandHandler : IRequestHandler<CreateTransportTypeCommand, CreatedTransportTypeResponse>
    {
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly IMapper _mapper;
        private readonly TransportTypeBusinessRules _rules;

        public CreateTransportTypeCommandHandler(ITransportTypeRepository transportTypeRepository, IMapper mapper, TransportTypeBusinessRules rules)
        {
            _transportTypeRepository = transportTypeRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CreatedTransportTypeResponse> Handle(CreateTransportTypeCommand request, CancellationToken cancellationToken)
        {
            await _rules.TypeCannotBeDuplicatedWhenInsertingOrUpdating(request.Type);
            
            TransportType transportType = _mapper.Map<TransportType>(request);
            await _transportTypeRepository.AddAsync(transportType);

            CreatedTransportTypeResponse response = _mapper.Map<CreatedTransportTypeResponse>(transportType);
            return response;
        }
    }
}
