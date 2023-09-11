using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Carriers.Queries.GetById
{
    public class GetByIdCarrierQueryHandler : IRequestHandler<GetByIdCarrierQuery, GetByIdCarrierResponse>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;

        public GetByIdCarrierQueryHandler(ICarrierRepository carrierRepository, IMapper mapper)
        {
            _carrierRepository = carrierRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCarrierResponse> Handle(GetByIdCarrierQuery request, CancellationToken cancellationToken)
        {
            Carrier? carrier = await _carrierRepository.GetAsync(
                e => e.EmployeeId == request.EmployeeId, 
                include: e => e.Include(e => e.Employee).Include(e => e.Employee.AppUser).Include(e => e.Employee.Company)
            );

            if (carrier is null)
                throw new NotFoundException("Carrier not found");

            GetByIdCarrierResponse response = _mapper.Map<GetByIdCarrierResponse>(carrier);
            return response;
        }
    }
}
