using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Update
{
    public class UpdateTransportTypeCommandHandler : IRequestHandler<UpdateTransportTypeCommand, UpdatedTransportTypeResponse>
    {
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly IMapper _mapper;

        public UpdateTransportTypeCommandHandler(ITransportTypeRepository transportTypeRepository, IMapper mapper)
        {
            _transportTypeRepository = transportTypeRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTransportTypeResponse> Handle(UpdateTransportTypeCommand request, CancellationToken cancellationToken)
        {
            TransportType? transportType = await _transportTypeRepository.GetAsync(e => e.Id == request.Id);
            if (transportType is null)
                throw new NotFoundException("Transport type not found");

            transportType.Type = request.Type;
            transportType.UpdatedDate = DateTime.UtcNow;
            await _transportTypeRepository.SaveChangesAsync();

            UpdatedTransportTypeResponse response = _mapper.Map< UpdatedTransportTypeResponse >(transportType);
            return response;
        }
    }
}
