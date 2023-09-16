using AutoMapper;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver;
using TransportathonHackathon.Application.Features.Languages.Commands.Create;
using TransportathonHackathon.Application.Features.Languages.Commands.Delete;
using TransportathonHackathon.Application.Features.Languages.Commands.Update;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Update;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Create;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Delete;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Update;
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
using TransportathonHackathon.WebAPI.Dtos.Driver;
using TransportathonHackathon.WebAPI.Dtos.Language;
using TransportathonHackathon.WebAPI.Dtos.PaymentRequests;
using TransportathonHackathon.WebAPI.Dtos.PickupTruck;
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

            CreateMap<CreatePickupTruckDto, CreatePickupTruckCommand>();
            CreateMap<DeletePickupTruckDto, DeletePickupTruckCommand>();
            CreateMap<UpdatePickupTruckDto, UpdatePickupTruckCommand>();

            CreateMap<CreatePaymentRequestDto, CreatePaymentRequestCommand>();
            CreateMap<DeletePaymentRequestDto, DeletePaymentRequestCommand>();
            CreateMap<UpdatePaymentRequestDto, UpdatePaymentRequestCommand>();
            CreateMap<PayPaymentRequestDto, PayPaymentRequestCommand>();

            CreateMap<CreateDriverDto, CreateDriverCommand>();
            CreateMap<DeleteDriverDto, DeleteDriverCommand>();
            CreateMap<UpdateDriverDto, UpdateDriverCommand>();

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
