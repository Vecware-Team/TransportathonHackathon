using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.Queries.GetByCompanyId
{
    public class GetByCompanyIdDriverQueryHandler : IRequestHandler<GetByCompanyIdDriverQuery, List<GetByCompanyIdDriverResponse>>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public GetByCompanyIdDriverQueryHandler(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByCompanyIdDriverResponse>> Handle(GetByCompanyIdDriverQuery request, CancellationToken cancellationToken)
        {
            IList<Driver> drivers = await _driverRepository.GetListAsync(
                e => e.Employee.CompanyId == request.CompanyId,
                include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser)
            );

            drivers.ToList().ForEach(e =>
            {
                e.Employee.Driver = null;
                e.Employee.Company.Employees = null;
                e.Employee.AppUser.Employee = null;
            });

            List<GetByCompanyIdDriverResponse> response = _mapper.Map<List<GetByCompanyIdDriverResponse>>(drivers);
            return response;
        }
    }
}
