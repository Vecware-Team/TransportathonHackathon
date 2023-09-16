using AutoMapper;
using TransportathonHackathon.Application.Features.Languages.Commands.Create;
using TransportathonHackathon.Application.Features.Languages.Commands.Delete;
using TransportathonHackathon.Application.Features.Languages.Commands.Update;
using TransportathonHackathon.Application.Features.Translates.Commands.Create;
using TransportathonHackathon.Application.Features.Translates.Commands.Delete;
using TransportathonHackathon.Application.Features.Translates.Commands.Update;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.AddVehicle;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Approve;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Create;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Update;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Create;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Update;
using TransportathonHackathon.Application.Features.Trucks.Commands.Create;
using TransportathonHackathon.Application.Features.Trucks.Commands.Delete;
using TransportathonHackathon.Application.Features.Trucks.Commands.Update;
using TransportathonHackathon.WebAPI.Dtos.Language;
using TransportathonHackathon.WebAPI.Dtos.Translate;
using TransportathonHackathon.WebAPI.Dtos.TransportRequest;
using TransportathonHackathon.WebAPI.Dtos.TransportType;
using TransportathonHackathon.WebAPI.Dtos.Truck;

namespace TransportathonHackathon.WebAPI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateLanguageDto, CreateLanguageCommand>();
            CreateMap<DeleteLanguageDto, DeleteLanguageCommand>();
            CreateMap<UpdateLanguageDto, UpdateLanguageCommand>();

            CreateMap<CreateTranslateDto, CreateTranslateCommand>();
            CreateMap<DeleteTranslateDto, DeleteTranslateCommand>();
            CreateMap<UpdateTranslateDto, UpdateTranslateCommand>();

            CreateMap<CreateTransportTypeDto, CreateTransportTypeCommand>();
            CreateMap<DeleteTransportTypeDto, DeleteTransportTypeCommand>();
            CreateMap<UpdateTransportTypeDto, UpdateTransportTypeCommand>();

            CreateMap<CreateTruckDto, CreateTruckCommand>();
            CreateMap<DeleteTruckDto, DeleteTruckCommand>();
            CreateMap<UpdateTruckDto, UpdateTruckCommand>();

            CreateMap<CreateTransportRequestDto, CreateTransportRequestCommand>();
            CreateMap<DeleteTransportRequestDto, DeleteTransportRequestCommand>();
            CreateMap<UpdateTransportRequestDto, UpdateTransportRequestCommand>();
            CreateMap<ApproveTransportRequestDto, ApproveTransportRequestCommand>();
            CreateMap<FinishTransportRequestDto, FinishTransportRequestCommand>();
            CreateMap<AddVehicleTransportRequestDto, AddVehicleTransportRequestCommand>();
            CreateMap<ApproveAndPayTransportRequestDto, ApproveAndPayTransportRequestCommand>();
        }
    }
}
