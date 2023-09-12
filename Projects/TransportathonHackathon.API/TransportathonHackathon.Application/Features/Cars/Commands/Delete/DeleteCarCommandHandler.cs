using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public DeleteCarCommandHandler(IVehicleRepository vehicleRepository, ICarRepository carRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver)
            );
            if (car is null)
                throw new NotFoundException("Car not found");

            Vehicle vehicle = _mapper.Map<Vehicle>(car.Vehicle);
            await _vehicleRepository.DeleteAsync(car.Vehicle);
            car.Vehicle = vehicle;

            DeletedCarResponse response = _mapper.Map<DeletedCarResponse>(car);
            return response;
        }
    }
}
