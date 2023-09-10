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
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, CreatedDriverDto>, ITransactionalRequest
    {
        private readonly IEmployeeRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly DriverBusinessRules _rules;
        private readonly IMapper _mapper;

        public CreateDriverCommandHandler(IEmployeeRepository repository, UserManager<AppUser> userManager, DriverBusinessRules rules, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _rules = rules;
            _mapper = mapper;
        }

        public async Task<CreatedDriverDto> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            //Driver mappedDriver = _mapper.Map<Driver>(request);
            //mappedDriver.Employee = new Employee
            //{
            //    IsOnTransitNow = false,
            //};

            IdentityResult result = await _userManager.CreateAsync(new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                CreatedDate = DateTime.UtcNow,
            }, request.Password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.ToString());

            AppUser addedUser = await _userManager.FindByEmailAsync(request.Email)!;

            Employee createdDriverEmployee = await _repository.AddAsync(new Employee
            {
                AppUserId = addedUser.Id,
                IsOnTransitNow = false,
                Driver = new Driver(),
                CompanyId = request.CompanyId,
                Age = request.Age,
                FirstName = request.FirstName,
                LastName = request.LastName,
            });

            CreatedDriverDto mappedDriverDto = _mapper.Map<CreatedDriverDto>(createdDriverEmployee.Driver);
            return mappedDriverDto;
        }
    }
}
