using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Create
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public CreateCarCommandHandler(ICarRepository carRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);
            Vehicle vehicle = await _vehicleRepository.AddAsync(new Vehicle()
            {
                CompanyId = request.CompanyId,
                DriverId = request.DriverId,
                CreatedDate = DateTime.UtcNow,
                Car = car,
            });

            car = await _carRepository.GetAsync(
                e => e.VehicleId == vehicle.Id, 
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver)
            );

            CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(car);
            return response;
        }
    }

}
