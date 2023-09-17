using AutoMapper;
using TransportathonHackathon.Application.Features.Carriers.Commands.Create;
using TransportathonHackathon.Application.Features.Carriers.Commands.Delete;
using TransportathonHackathon.Application.Features.Carriers.Commands.Update;
using TransportathonHackathon.Application.Features.Cars.Commands.Create;
using TransportathonHackathon.Application.Features.Cars.Commands.Delete;
using TransportathonHackathon.Application.Features.Cars.Commands.Update;
using TransportathonHackathon.Application.Features.Comments.Commands.Create;
using TransportathonHackathon.Application.Features.Comments.Commands.Delete;
using TransportathonHackathon.Application.Features.Comments.Commands.Update;
using TransportathonHackathon.Application.Features.Companies.Commands.Create;
using TransportathonHackathon.Application.Features.Companies.Commands.Delete;
using TransportathonHackathon.Application.Features.Companies.Commands.Update;
using TransportathonHackathon.Application.Features.Customers.Commands.Create;
using TransportathonHackathon.Application.Features.Customers.Commands.Delete;
using TransportathonHackathon.Application.Features.Customers.Commands.Update;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Delete;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Update;
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
using TransportathonHackathon.WebAPI.Dtos.Car;
using TransportathonHackathon.WebAPI.Dtos.Carrier;
using TransportathonHackathon.WebAPI.Dtos.Comment;
using TransportathonHackathon.WebAPI.Dtos.Company;
using TransportathonHackathon.WebAPI.Dtos.Customer;
using TransportathonHackathon.WebAPI.Dtos.Driver;
using TransportathonHackathon.WebAPI.Dtos.DriverLicense;
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
            
            CreateMap<CreateCustomerDto, CreateCustomerCommand>();
            CreateMap<DeleteCustomerDto, DeleteCustomerCommand>();
            CreateMap<UpdateCustomerDto, UpdateCustomerCommand>();

            CreateMap<CreateCompanyDto, CreateCompanyCommand>();
            CreateMap<DeleteCompanyDto, DeleteCompanyCommand>();
            CreateMap<UpdateCompanyDto, UpdateCompanyCommand>();
            
            CreateMap<CreateDriverLicenseDto, CreateDriverLicenseCommand>();
            CreateMap<DeleteDriverLicenseDto, DeleteDriverLicenseCommand>();
            CreateMap<UpdateDriverLicenseDto, UpdateDriverLicenseCommand>();

            CreateMap<CreateCarDto, CreateCarCommand>();
            CreateMap<DeleteCarDto, DeleteCarCommand>();
            CreateMap<UpdateCarDto, UpdateCarCommand>();

            CreateMap<CreateCarrierDto, CreateCarrierCommand>();
            CreateMap<DeleteCarrierDto, DeleteCarrierCommand>();
            CreateMap<UpdateCarrierDto, UpdateCarrierCommand>();

            CreateMap<CreateCommentDto, CreateCommentCommand>();
            CreateMap<DeleteCommentDto, DeleteCommentCommand>();
            CreateMap<UpdateCommentDto, UpdateCommentCommand>();

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
