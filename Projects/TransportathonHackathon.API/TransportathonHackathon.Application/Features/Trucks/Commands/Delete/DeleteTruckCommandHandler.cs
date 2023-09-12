using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Delete
{
    public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand, DeletedTruckResponse>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public DeleteTruckCommandHandler(ITruckRepository truckRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTruckResponse> Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
        {
            Truck? truck = await _truckRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e=>e.Vehicle.Driver.Employee)
            );
            if (truck is null)
                throw new NotFoundException("Truck not found");

            Vehicle vehicle = _mapper.Map<Vehicle>(truck.Vehicle);
            await _vehicleRepository.DeleteAsync(truck.Vehicle, true);
            truck.Vehicle = vehicle;

            DeletedTruckResponse response = _mapper.Map<DeletedTruckResponse>(truck);
            return response;
        }
    }
}
