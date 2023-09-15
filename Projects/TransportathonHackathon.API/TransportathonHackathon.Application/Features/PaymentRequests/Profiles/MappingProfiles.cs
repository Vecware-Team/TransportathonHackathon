using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Update;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetByCompanyId;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetById;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PaymentRequest, CreatePaymentRequestCommand>().ReverseMap();
            CreateMap<PaymentRequest, CreatedPaymentRequestResponse>().ReverseMap();

            CreateMap<PaymentRequest, DeletedPaymentRequestResponse>().ReverseMap();
            
            CreateMap<PaymentRequest, UpdatePaymentRequestCommand>().ReverseMap();
            CreateMap<PaymentRequest, UpdatedPaymentRequestResponse>().ReverseMap();

            CreateMap<PaymentRequest, PaidPaymentRequestResponse>().ReverseMap();

            CreateMap<PaymentRequest, GetByIdPaymentRequestResponse>().ReverseMap();
            
            CreateMap<PaymentRequest, GetListPaymentRequestResponse>().ReverseMap();
            CreateMap<Paginate<PaymentRequest>, Paginate<GetListPaymentRequestResponse>>().ReverseMap();
            
            CreateMap<PaymentRequest, GetByCompanyIdPaymentRequestResponse>().ReverseMap();
            CreateMap<Paginate<PaymentRequest>, Paginate<GetByCompanyIdPaymentRequestResponse>>().ReverseMap();
        }
    }
}
