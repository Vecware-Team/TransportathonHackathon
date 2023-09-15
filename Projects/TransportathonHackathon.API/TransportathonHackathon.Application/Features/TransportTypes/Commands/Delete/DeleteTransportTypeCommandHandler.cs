using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete
{
    public class DeleteTransportTypeCommandHandler : IRequestHandler<DeleteTransportTypeCommand, DeletedTransportTypeResponse>
    {
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly IMapper _mapper;

        public DeleteTransportTypeCommandHandler(ITransportTypeRepository transportTypeRepository, IMapper mapper)
        {
            _transportTypeRepository = transportTypeRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTransportTypeResponse> Handle(DeleteTransportTypeCommand request, CancellationToken cancellationToken)
        {
            TransportType? transportType = await _transportTypeRepository.GetAsync(e => e.Id == request.Id);
            if (transportType is null)
                throw new NotFoundException("Transport type not found");

            await _transportTypeRepository.DeleteAsync(transportType, true);
            DeletedTransportTypeResponse response = _mapper.Map<DeletedTransportTypeResponse>(transportType);
            return response;
        }
    }
}
