using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Commands.Create
{
    public class CreatePickupTruckCommandHandler : IRequestHandler<CreatePickupTruckCommand, CreatedPickupTruckResponse>
    {
        private readonly IPickupTruckRepository _pickupTruckRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public CreatePickupTruckCommandHandler(IPickupTruckRepository pickupTruckRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _pickupTruckRepository = pickupTruckRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<CreatedPickupTruckResponse> Handle(CreatePickupTruckCommand request, CancellationToken cancellationToken)
        {
            PickupTruck pickupTruck = _mapper.Map<PickupTruck>(request);
            Vehicle vehicle = await _vehicleRepository.AddAsync(new Vehicle()
            {
                CompanyId = request.CompanyId,
                DriverId = request.DriverId,
                CreatedDate = DateTime.UtcNow,
                PickupTruck = pickupTruck,
            });

            pickupTruck = await _pickupTruckRepository.GetAsync(
                e => e.VehicleId == vehicle.Id,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e=>e.Vehicle.Driver.Employee)
            );

            CreatedPickupTruckResponse response = _mapper.Map<CreatedPickupTruckResponse>(pickupTruck);
            return response;
        }
    }
}
