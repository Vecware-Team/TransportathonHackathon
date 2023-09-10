using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Companies.Commands.Delete;
using TransportathonHackathon.Application.Features.Drivers.Dtos;
using TransportathonHackathon.Application.Features.Drivers.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver
{
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, DeletedDriverResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly DriverBusinessRules _businessRules;
        private readonly IMapper _mapper;
        public DeleteDriverCommandHandler(IEmployeeRepository employeeRepository, DriverBusinessRules businessRules, IMapper mapper, UserManager<AppUser> userManager)
        {
            _employeeRepository = employeeRepository;
            _businessRules = businessRules;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<DeletedDriverResponse> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _employeeRepository.GetAsync(e => e.AppUserId == request.EmployeeId, include: e => e.Include(e => e.AppUser));

            AppUser user = new AppUser()
            {
                UserName = employee.AppUser.UserName,
                Email = employee.AppUser.Email,
            };

            IdentityResult result = await _userManager.DeleteAsync(employee.AppUser);
            if (!result.Succeeded)
                throw new Exception();

            employee.AppUser = user;
            DeletedDriverResponse response = _mapper.Map<DeletedDriverResponse>(employee);
            return response;
        }
    }
}
