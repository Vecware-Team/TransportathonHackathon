using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Employees.Queries.GetByCompanyId
{
    public class GetByCompanyIdEmployeeQueryHandler : IRequestHandler<GetByCompanyIdEmployeeQuery, List<GetByCompanyIdEmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetByCompanyIdEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByCompanyIdEmployeeResponse>> Handle(GetByCompanyIdEmployeeQuery request, CancellationToken cancellationToken)
        {
            IList<Employee> employees = await _employeeRepository.GetListAsync(
                e => e.CompanyId == request.CompanyId,
                include: e => e.Include(e => e.Driver).Include(e => e.Carrier).Include(e => e.AppUser)
            );

            employees.ToList().ForEach(e =>
            {
                e.AppUser.Employee = null;
                if (e.Driver is not null)
                    e.Driver.Employee = null;
                if (e.Carrier is not null)
                    e.Carrier.Employee = null;
            });

            List<GetByCompanyIdEmployeeResponse> response = _mapper.Map<List<GetByCompanyIdEmployeeResponse>>(employees);
            return response;
        }
    }
}
