using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Commands.Delete
{
    public class DeletePickupTruckCommandHandler : IRequestHandler<DeletePickupTruckCommand, DeletedPickupTruckResponse>
    {
        private readonly IPickupTruckRepository _pickupTruckRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public DeletePickupTruckCommandHandler(IPickupTruckRepository pickupTruckRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _pickupTruckRepository = pickupTruckRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<DeletedPickupTruckResponse> Handle(DeletePickupTruckCommand request, CancellationToken cancellationToken)
        {
            PickupTruck? pickupTruck = await _pickupTruckRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee)
            );
            if (pickupTruck is null)
                throw new NotFoundException("Pickup truck not found");

            Vehicle vehicle = _mapper.Map<Vehicle>(pickupTruck.Vehicle);
            await _vehicleRepository.DeleteAsync(pickupTruck.Vehicle, true);
            pickupTruck.Vehicle = vehicle;

            DeletedPickupTruckResponse response = _mapper.Map<DeletedPickupTruckResponse>(pickupTruck);
            return response;
        }
    }
}
