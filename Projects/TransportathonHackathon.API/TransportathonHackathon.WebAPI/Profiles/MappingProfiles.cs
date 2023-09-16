using AutoMapper;
using TransportathonHackathon.Application.Features.Languages.Commands.Create;
using TransportathonHackathon.Application.Features.Languages.Commands.Delete;
using TransportathonHackathon.Application.Features.Languages.Commands.Update;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.AddVehicle;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Approve;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Create;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Update;
using TransportathonHackathon.WebAPI.Dtos;
using TransportathonHackathon.WebAPI.Dtos.Language;
using TransportathonHackathon.WebAPI.Dtos.TransportRequest;

namespace TransportathonHackathon.WebAPI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateLanguageDto, CreateLanguageCommand>();
            CreateMap<DeleteLanguageDto, DeleteLanguageCommand>();
            CreateMap<UpdateLanguageDto, UpdateLanguageCommand>();

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
