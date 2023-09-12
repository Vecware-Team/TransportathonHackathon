using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Trucks.Queries.GetById
{
    public class GetByIdTruckQueryHandler : IRequestHandler<GetByIdTruckQuery, GetByIdTruckResponse>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IMapper _mapper;

        public GetByIdTruckQueryHandler(ITruckRepository truckRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTruckResponse> Handle(GetByIdTruckQuery request, CancellationToken cancellationToken)
        {
            Truck? truck = await _truckRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee)
            );
            if (truck is null)
                throw new NotFoundException("Truck not found");

            GetByIdTruckResponse response = _mapper.Map<GetByIdTruckResponse>(truck);
            return response;
        }
    }
}
