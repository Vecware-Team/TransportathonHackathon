using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetById
{
    public class GetByIdPickupTruckQueryHandler : IRequestHandler<GetByIdPickupTruckQuery, GetByIdPickupTruckResponse>
    {
        private readonly IPickupTruckRepository _pickupTruckRepository;
        private readonly IMapper _mapper;

        public GetByIdPickupTruckQueryHandler(IPickupTruckRepository pickupTruckRepository, IMapper mapper)
        {
            _pickupTruckRepository = pickupTruckRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPickupTruckResponse> Handle(GetByIdPickupTruckQuery request, CancellationToken cancellationToken)
        {
            PickupTruck? pickupTruck = await _pickupTruckRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee)
            );
            if (pickupTruck is null)
                throw new NotFoundException("Truck not found");

            GetByIdPickupTruckResponse response = _mapper.Map<GetByIdPickupTruckResponse>(pickupTruck);
            return response;
        }
    }
}
