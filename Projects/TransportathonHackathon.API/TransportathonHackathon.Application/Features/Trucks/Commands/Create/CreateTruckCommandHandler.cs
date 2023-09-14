using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Create
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, CreatedTruckResponse>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public CreateTruckCommandHandler(ITruckRepository truckRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<CreatedTruckResponse> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            Truck truck = _mapper.Map<Truck>(request);
            Vehicle vehicle = await _vehicleRepository.AddAsync(new Vehicle()
            {
                CompanyId = request.CompanyId,
                DriverId = request.DriverId,
                Brand = request.Brand,
                Model = request.Model,
                ModelYear = request.ModelYear,
                CreatedDate = DateTime.UtcNow,
                Truck = truck,
            });

            truck = await _truckRepository.GetAsync(
                e => e.VehicleId == vehicle.Id,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee)
            );

            CreatedTruckResponse response = _mapper.Map<CreatedTruckResponse>(truck);
            return response;
        }
    }
}
