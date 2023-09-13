using AutoMapper;
using TransportathonHackathon.Application.Features.Employees.Queries.GetByCompanyId;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Employees.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, GetByCompanyIdEmployeeResponse>().ReverseMap();
        }
    }
}
