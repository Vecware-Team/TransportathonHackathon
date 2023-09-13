using AutoMapper;
using TransportathonHackathon.Application.Features.Vehicles.Queries.GetByCompanyIdVehicle;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Vehicles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Vehicle, GetByCompanyIdVehicleResponse>().ReverseMap();
        }
    }
}
