using AutoMapper;
using Core.Application.Pipelines.Transaction;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Companies.Commands.Create;
using TransportathonHackathon.Application.Features.Drivers.Dtos;
using TransportathonHackathon.Application.Features.Drivers.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, CreatedDriverResponse>, ITransactionalRequest
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DriverBusinessRules _rules;
        private readonly IMapper _mapper;

        public CreateDriverCommandHandler(UserManager<AppUser> userManager, DriverBusinessRules rules, IMapper mapper)
        {
            _userManager = userManager;
            _rules = rules;
            _mapper = mapper;
        }

        public async Task<CreatedDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            Employee driverEmployee = new Employee
            {
                IsOnTransitNow = false,
                Driver = new Driver(),
                CompanyId = request.CompanyId,
                Age = request.Age,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            IdentityResult result = await _userManager.CreateAsync(new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                CreatedDate = DateTime.UtcNow,
                Employee = driverEmployee,
            }, request.Password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.ToString());

            AppUser addedUser = await _userManager.FindByEmailAsync(request.Email)!;

            CreatedDriverResponse mappedDriverDto = _mapper.Map<CreatedDriverResponse>(addedUser.Employee);
            return mappedDriverDto;
        }
    }
}
