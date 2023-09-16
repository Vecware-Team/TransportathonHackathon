using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.AddVehicle
{
    public class AddVehicleTransportRequestCommandHandler : IRequestHandler<AddVehicleTransportRequestCommand, AddVehicleTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public AddVehicleTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<AddVehicleTransportRequestResponse> Handle(AddVehicleTransportRequestCommand request, CancellationToken cancellationToken)
        {
            TransportRequest? transportRequest = await _transportRequestRepository.GetAsync(
                e => e.Id == request.Id,
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest).Include(e => e.Vehicle)
            );
            if (transportRequest is null)
                throw new NotFoundException("Transport request not found");

            transportRequest.VehicleId = request.VehicleId;
            transportRequest = await _transportRequestRepository.GetAsync(
                e => e.Id == request.Id,
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest).Include(e => e.Vehicle)
            );

            if (transportRequest.Vehicle is not null)
                transportRequest.Vehicle.TransportRequest = null;

            AddVehicleTransportRequestResponse response = _mapper.Map<AddVehicleTransportRequestResponse>(transportRequest);
            return response;
        }
    }
}
