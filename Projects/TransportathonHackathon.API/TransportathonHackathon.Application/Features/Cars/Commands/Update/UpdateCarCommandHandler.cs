using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Update
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee)
            );
            if (car is null)
                throw new NotFoundException("Car not found");

            car.Vehicle.CompanyId = request.CompanyId;
            car.Vehicle.DriverId = request.DriverId;
            car.Vehicle.UpdatedDate = DateTime.UtcNow;
            car.Vehicle.Brand = request.Brand;
            car.Vehicle.Model = request.Model;
            car.Vehicle.ModelYear = request.ModelYear;
            car.UpdatedDate = DateTime.Now;

            await _carRepository.SaveChangesAsync();
            car = await _carRepository.GetAsync(
               e => e.VehicleId == request.VehicleId,
               include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee)
           );

            UpdatedCarResponse response = _mapper.Map<UpdatedCarResponse>(car);
            return response;
        }
    }
}
