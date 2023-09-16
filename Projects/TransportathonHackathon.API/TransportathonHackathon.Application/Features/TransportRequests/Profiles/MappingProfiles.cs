using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Approve;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Create;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Update;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyAndCustomer;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyId;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCustomerId;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetById;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TransportRequest, CreateTransportRequestCommand>().ReverseMap();
            CreateMap<TransportRequest, CreatedTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, DeletedTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, UpdateTransportRequestCommand>().ReverseMap();
            CreateMap<TransportRequest, UpdatedTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, ApproveTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, FinishedTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, ApproveAndPayTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, GetByIdTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, GetListTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();
            CreateMap<Paginate<TransportRequest>, Paginate<GetListTransportRequestResponse>>().ReverseMap();

            CreateMap<TransportRequest, GetByCustomerIdTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Company.AppUserId))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, GetByCompanyIdTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();

            CreateMap<TransportRequest, GetByCompanyAndCustomerTransportRequestResponse>()
                .ForMember(destinationMember: e => e.TransportType, memberOptions: opt => opt.MapFrom(e => e.TransportType.Type))
                .ForMember(destinationMember: e => e.IsPaid, memberOptions: opt => opt.MapFrom(e => e.PaymentRequest.IsPaid))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Company.CompanyName))
                .ForMember(destinationMember: e => e.CustomerFirstName, memberOptions: opt => opt.MapFrom(e => e.Customer.FirstName))
                .ForMember(destinationMember: e => e.CustomerLastName, memberOptions: opt => opt.MapFrom(e => e.Customer.LastName))
                .ReverseMap();
        }
    }
}
