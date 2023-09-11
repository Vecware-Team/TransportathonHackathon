using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Features.Drivers.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver
{
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, UpdatedDriverResponse>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        private readonly DriverBusinessRules _driverBusinessRules;

        public UpdateDriverCommandHandler(IDriverRepository driverRepository, IMapper mapper, DriverBusinessRules driverBusinessRules)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
            _driverBusinessRules = driverBusinessRules;
        }

        public async Task<UpdatedDriverResponse> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            Driver? driver = await _driverRepository.GetAsync(
                e => e.EmployeeId == request.EmployeeId,
                include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser),
                cancellationToken: cancellationToken
            );

            if (driver is null)
                throw new NotFoundException("Driver not found");

            driver.Employee.FirstName = request.FirstName;
            driver.Employee.LastName = request.LastName;
            driver.Employee.Age = request.Age;
            driver.Employee.CompanyId = request.CompanyId;
            driver.UpdatedDate = DateTime.UtcNow;
            driver.Employee.AppUser.Email = request.Email;
            driver.Employee.AppUser.UserName = request.UserName;
            driver.Employee.UpdatedDate = DateTime.UtcNow;
            driver.Employee.AppUser.UpdatedDate = DateTime.Now;

            await _driverRepository.SaveChangesAsync();

            driver = await _driverRepository.GetAsync(
                e => e.EmployeeId == request.EmployeeId,
                include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser),
                cancellationToken: cancellationToken
            );
            UpdatedDriverResponse response = _mapper.Map<UpdatedDriverResponse>(driver);
            return response;
        }
    }
}
