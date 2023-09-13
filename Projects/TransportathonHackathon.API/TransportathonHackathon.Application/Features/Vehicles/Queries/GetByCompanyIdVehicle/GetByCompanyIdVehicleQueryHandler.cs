using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Vehicles.Queries.GetByCompanyIdVehicle
{
    public class GetByCompanyIdVehicleQueryHandler : IRequestHandler<GetByCompanyIdVehicleQuery, List<GetByCompanyIdVehicleResponse>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetByCompanyIdVehicleQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByCompanyIdVehicleResponse>> Handle(GetByCompanyIdVehicleQuery request, CancellationToken cancellationToken)
        {
            IList<Vehicle> vehicles = await _vehicleRepository.GetListAsync(
                e => e.CompanyId == request.CompanyId,
                include: e => e.Include(e => e.Driver).Include(e => e.Car).Include(e => e.Truck).Include(e => e.PickupTruck)
            );

            vehicles.ToList().ForEach(e =>
            {
                if (e.Driver is not null)
                    e.Driver.Vehicles = null;
                if (e.Car is not null)
                    e.Car.Vehicle = null;
                if (e.Truck is not null)
                    e.Truck.Vehicle = null;
                if (e.PickupTruck is not null)
                    e.PickupTruck.Vehicle = null;
            });

            List<GetByCompanyIdVehicleResponse> response = _mapper.Map<List<GetByCompanyIdVehicleResponse>>(vehicles);
            return response;
        }
    }
}
