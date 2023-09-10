using AutoMapper;
using Core.Persistence.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver;
using TransportathonHackathon.Application.Features.Drivers.Dtos;
using TransportathonHackathon.Application.Features.Drivers.Responses;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Driver, CreatedDriverResponse>().ReverseMap();
            CreateMap<Driver, CreateDriverCommand>().ReverseMap();
            CreateMap<Employee, CreatedDriverResponse>()
                .ForMember(e => e.EmployeeId, d => d.MapFrom(d => d.AppUserId)).ReverseMap()
                .ForMember(e => e.IsOnTransitNow, d => d.MapFrom(d => d.IsOnTransitNow)).ReverseMap();

            CreateMap<Employee, DeletedDriverResponse>().ReverseMap();

            CreateMap<Employee, UpdateDriverCommand>().ReverseMap();
            CreateMap<Employee, UpdatedDriverResponse>().ReverseMap();

            CreateMap<Paginate<GetListDriverResponse>, IPaginate<Employee>>()
                .ForMember(e=>e.Items.Select(e=>e.Driver).ToList(), opt=>opt.MapFrom(d=>d.Items)).ReverseMap();

            

        }
    }
}
