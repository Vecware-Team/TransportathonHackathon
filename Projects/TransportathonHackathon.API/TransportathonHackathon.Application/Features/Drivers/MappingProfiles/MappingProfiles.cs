using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Application.Features.Drivers.Dtos;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Driver, CreatedDriverDto>().ReverseMap();
            CreateMap<Driver, CreateDriverCommand>().ReverseMap();
            CreateMap<CreatedDriverDto, Employee>().ForMember(e => e.AppUserId, d => d.MapFrom(d => d.EmployeeId)).ReverseMap();
            CreateMap<CreatedDriverDto, Employee>().ForMember(e => e.IsOnTransitNow, d => d.MapFrom(d => d.IsOnTransitNow)).ReverseMap();



        }
    }
}
