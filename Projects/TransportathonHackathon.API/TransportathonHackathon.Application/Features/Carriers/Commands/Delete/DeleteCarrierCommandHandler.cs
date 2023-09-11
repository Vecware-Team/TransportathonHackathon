using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Delete
{
    public class DeleteCarrierCommandHandler : IRequestHandler<DeleteCarrierCommand, DeletedCarrierResponse>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public DeleteCarrierCommandHandler(ICarrierRepository carrierRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _carrierRepository = carrierRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<DeletedCarrierResponse> Handle(DeleteCarrierCommand request, CancellationToken cancellationToken)
        {
            Carrier? carrier = await _carrierRepository.GetAsync(e => e.EmployeeId == request.EmployeeId, include:e=>e.Include(e=>e.Employee).Include(e=>e.Employee.Company).Include(e=>e.Employee.AppUser));
            if (carrier is null)
                throw new NotFoundException("Carrier not found");

            Employee employee = _mapper.Map<Employee>(carrier.Employee);
            AppUser appUser = _mapper.Map<AppUser>(employee.AppUser);

            IdentityResult result = await _userManager.DeleteAsync(employee.AppUser);
            if (!result.Succeeded)
                throw new BusinessException(result.Errors.Select(e => e.Description).ToString());

            employee.AppUser = appUser;
            carrier.Employee = employee;
            DeletedCarrierResponse response = _mapper.Map<DeletedCarrierResponse>(carrier);
            return response;
        }
    }
}
