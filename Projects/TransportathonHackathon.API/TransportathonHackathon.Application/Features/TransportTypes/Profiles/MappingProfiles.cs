using AutoMapper;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Create;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Update;
using TransportathonHackathon.Application.Features.TransportTypes.Queries.GetById;
using TransportathonHackathon.Application.Features.TransportTypes.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportTypes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TransportType, CreateTransportTypeCommand>().ReverseMap();
            CreateMap<TransportType, CreatedTransportTypeResponse>().ReverseMap();

            CreateMap<TransportType, DeletedTransportTypeResponse>().ReverseMap();
            
            CreateMap<TransportType, UpdateTransportTypeCommand>().ReverseMap();
            CreateMap<TransportType, UpdatedTransportTypeResponse>().ReverseMap();

            CreateMap<TransportType, GetByIdTransportTypeResponse>().ReverseMap();

            CreateMap<TransportType, GetListTransportTypeResponse>().ReverseMap();
        }
    }
}
