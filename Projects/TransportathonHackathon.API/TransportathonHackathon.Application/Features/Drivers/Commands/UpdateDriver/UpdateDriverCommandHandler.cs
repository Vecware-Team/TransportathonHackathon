using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Companies.Commands.Update;
using TransportathonHackathon.Application.Features.Drivers.Dtos;
using TransportathonHackathon.Application.Features.Drivers.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver
{
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, UpdatedDriverResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly DriverBusinessRules _driverBusinessRules;

        public UpdateDriverCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, DriverBusinessRules driverBusinessRules)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _driverBusinessRules = driverBusinessRules;
        }

        public async Task<UpdatedDriverResponse> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            Employee employeeToUpdate = _mapper.Map<Employee>(request);

            Employee? employee = await _employeeRepository.GetAsync(
                d => d.AppUserId == request.EmployeeId,
                include: e => e.Include(e => e.AppUser),
                cancellationToken: cancellationToken
            );

            if (employee is null)
                throw new Exception();

            employee.FirstName = employeeToUpdate.FirstName;
            employee.LastName = employeeToUpdate.LastName;
            employee.Age = employeeToUpdate.Age;
            employee.CompanyId = employeeToUpdate.CompanyId;
            employee.IsOnTransitNow = employeeToUpdate.IsOnTransitNow;

            employee.AppUser.UpdatedDate = DateTime.UtcNow;

            await _employeeRepository.SaveChangesAsync();

            UpdatedDriverResponse response = _mapper.Map<UpdatedDriverResponse>(employee);
            return response;
        }
    }
}
