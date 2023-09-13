using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Carriers.Queries.GetByCompanyId
{
    public class GetByCompanyIdCarrierQueryHandler : IRequestHandler<GetByCompanyIdCarrierQuery, List<GetByCompanyIdCarrierResponse>>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;

        public GetByCompanyIdCarrierQueryHandler(ICarrierRepository carrierRepository, IMapper mapper)
        {
            _carrierRepository = carrierRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByCompanyIdCarrierResponse>> Handle(GetByCompanyIdCarrierQuery request, CancellationToken cancellationToken)
        {
            IList<Carrier> drivers = await _carrierRepository.GetListAsync(
                e => e.Employee.CompanyId == request.CompanyId,
                include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser)
            );

            drivers.ToList().ForEach(e =>
            {
                e.Employee.Driver = null;
                e.Employee.Company.Employees = null;
                e.Employee.AppUser.Employee = null;
            });

            List<GetByCompanyIdCarrierResponse> response = _mapper.Map<List<GetByCompanyIdCarrierResponse>>(drivers);
            return response;
        }
    }
}
