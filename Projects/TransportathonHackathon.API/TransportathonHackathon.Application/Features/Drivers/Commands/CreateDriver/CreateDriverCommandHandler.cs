using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;


        public CreateDriverCommandHandler(UserManager<AppUser> userManager, DriverBusinessRules rules, IMapper mapper, IDriverRepository driverRepository)
        {
            _userManager = userManager;
            _rules = rules;
            _mapper = mapper;
            _driverRepository = driverRepository;
        }

        public async Task<CreatedDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            Driver driver = _mapper.Map<Driver>(request);

            IdentityResult result = await _userManager.CreateAsync(new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                CreatedDate = DateTime.UtcNow,
                Employee = new Employee()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Age = request.Age,
                    IsOnTransitNow = false,
                    CreatedDate = DateTime.UtcNow,
                    CompanyId = request.CompanyId,
                    Driver = driver,
                },
            }, request.Password);

            if (!result.Succeeded)
                throw new BusinessException(result.Errors.ToString());

            AppUser appuser = await _userManager.FindByEmailAsync(request.Email);
            driver = await _driverRepository.GetAsync(e => e.EmployeeId == appuser.Id, include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser));

            CreatedDriverResponse response = _mapper.Map<CreatedDriverResponse>(driver);
            return response;
        }
    }
}
