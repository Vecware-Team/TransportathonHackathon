using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TransportathonHackathon.Application.Features.Drivers.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver
{
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, DeletedDriverResponse>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly DriverBusinessRules _businessRules;
        private readonly IMapper _mapper;
        public DeleteDriverCommandHandler(IDriverRepository driverRepository, DriverBusinessRules businessRules, IMapper mapper, UserManager<AppUser> userManager)
        {
            _driverRepository = driverRepository;
            _businessRules = businessRules;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<DeletedDriverResponse> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            Driver? driver = await _driverRepository.GetAsync(e => e.EmployeeId == request.EmployeeId, include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser));
            if (driver is null)
                throw new NotFoundException("Driver not found");

            Employee employee = _mapper.Map<Employee>(driver.Employee);
            AppUser appUser = _mapper.Map<AppUser>(employee.AppUser);

            IdentityResult result = await _userManager.DeleteAsync(employee.AppUser);
            if (!result.Succeeded)
                throw new BusinessException(result.Errors.Select(e => e.Description).ToString());

            employee.AppUser = appUser;
            driver.Employee = employee;

            DeletedDriverResponse response = _mapper.Map<DeletedDriverResponse>(driver);
            return response;
        }
    }
}
