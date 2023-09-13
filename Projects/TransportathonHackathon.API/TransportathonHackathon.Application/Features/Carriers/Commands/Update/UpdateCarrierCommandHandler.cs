using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TransportathonHackathon.Application.Extensions;
using TransportathonHackathon.Application.Features.Carriers.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Update
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommand, UpdatedCarrierResponse>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;
        private readonly CarrierBusinessRules _rules;

        public UpdateCarrierCommandHandler(ICarrierRepository carrierRepository, IMapper mapper, CarrierBusinessRules rules)
        {
            _carrierRepository = carrierRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedCarrierResponse> Handle(UpdateCarrierCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfUserEmailorUserNameDuplicatedWhenInserting(request.Email, request.UserName);
            Carrier? carrier = await _carrierRepository.GetAsync(e => e.EmployeeId == request.EmployeeId, include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e=>e.Employee.AppUser));
            if (carrier is null)
                throw new NotFoundException("Carrier not found");

            carrier.Employee.AppUser.UserName = request.UserName;
            carrier.Employee.AppUser.Email = request.Email;
            carrier.Employee.FirstName = request.FirstName;
            carrier.Employee.LastName = request.LastName;
            carrier.Employee.Age = request.Age;
            carrier.Employee.CompanyId = request.CompanyId;
            carrier.UpdatedDate = DateTime.UtcNow;
            carrier.Employee.UpdatedDate = DateTime.UtcNow;
            carrier.Employee.AppUser.UpdatedDate = DateTime.UtcNow;

            await _carrierRepository.SaveChangesAsync();

            carrier = await _carrierRepository.GetAsync(e => e.EmployeeId == request.EmployeeId, include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser));
            UpdatedCarrierResponse response = _mapper.Map<UpdatedCarrierResponse>(carrier);
            return response;
        }
    }
}
