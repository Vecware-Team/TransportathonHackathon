using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyAndCustomer
{
    public class GetByCompanyAndCustomerTransportRequestQuery : IRequest<List<GetByCompanyAndCustomerTransportRequestResponse>>
    {
        public Guid CompanyId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
