using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Create
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommand, CreatedCarrierResponse>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CreateCarrierCommandHandler(UserManager<AppUser> userManager, IMapper mapper, ICarrierRepository carrierRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _carrierRepository = carrierRepository;
        }

        public async Task<CreatedCarrierResponse> Handle(CreateCarrierCommand request, CancellationToken cancellationToken)
        {
            Carrier carrier = _mapper.Map<Carrier>(request);

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
                    Carrier = carrier
                },
            }, request.Password);

            if (!result.Succeeded)
                throw new BusinessException(result.Errors.Select(e => e.Description).ToString());

            AppUser appuser = await _userManager.FindByEmailAsync(request.Email);
            carrier = await _carrierRepository.GetAsync(e => e.EmployeeId == appuser.Id, include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e=>e.Employee.AppUser));

            CreatedCarrierResponse response = _mapper.Map<CreatedCarrierResponse>(carrier);
            return response;
        }
    }
}
