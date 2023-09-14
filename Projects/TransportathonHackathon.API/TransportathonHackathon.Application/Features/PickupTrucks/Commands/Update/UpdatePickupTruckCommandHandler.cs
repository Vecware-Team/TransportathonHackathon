using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Commands.Update
{
    public class UpdatePickupTruckCommandHandler : IRequestHandler<UpdatePickupTruckCommand, UpdatedPickupTruckResponse>
    {
        private readonly IPickupTruckRepository _pickupTruckRepository;
        private readonly IMapper _mapper;

        public UpdatePickupTruckCommandHandler(IPickupTruckRepository pickupTruckRepository, IMapper mapper)
        {
            _pickupTruckRepository = pickupTruckRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedPickupTruckResponse> Handle(UpdatePickupTruckCommand request, CancellationToken cancellationToken)
        {
            PickupTruck? pickupTruck = await _pickupTruckRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee)
            );
            if (pickupTruck is null)
                throw new NotFoundException("Pickup truck not found");

            pickupTruck.Vehicle.CompanyId = request.CompanyId;
            pickupTruck.Vehicle.DriverId = request.DriverId;
            pickupTruck.Vehicle.UpdatedDate = DateTime.UtcNow;
            pickupTruck.Vehicle.Brand = request.Brand;
            pickupTruck.Vehicle.Model = request.Model;
            pickupTruck.Vehicle.ModelYear = request.ModelYear;
            pickupTruck.Size = request.Size;
            pickupTruck.UpdatedDate = DateTime.Now;

            await _pickupTruckRepository.SaveChangesAsync();
            pickupTruck = await _pickupTruckRepository.GetAsync(
               e => e.VehicleId == request.VehicleId,
               include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee)
           );

            UpdatedPickupTruckResponse response = _mapper.Map<UpdatedPickupTruckResponse>(pickupTruck);
            return response;
        }
    }
}
