using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Update
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand, UpdatedTruckResponse>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IMapper _mapper;

        public UpdateTruckCommandHandler(ITruckRepository truckRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTruckResponse> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            Truck? truck = await _truckRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver)
            );
            if (truck is null)
                throw new NotFoundException("Truck not found");

            truck.Vehicle.CompanyId = request.CompanyId;
            truck.Vehicle.DriverId = request.DriverId;
            truck.Vehicle.UpdatedDate = DateTime.UtcNow;
            truck.Brand = request.Brand;
            truck.Model = request.Model;
            truck.ModelYear = request.ModelYear;
            truck.Size = request.Size;
            truck.UpdatedDate = DateTime.Now;

            await _truckRepository.SaveChangesAsync();
            truck = await _truckRepository.GetAsync(
               e => e.VehicleId == request.VehicleId,
               include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver)
           );

            UpdatedTruckResponse response = _mapper.Map<UpdatedTruckResponse>(truck);
            return response;
        }
    }
}
