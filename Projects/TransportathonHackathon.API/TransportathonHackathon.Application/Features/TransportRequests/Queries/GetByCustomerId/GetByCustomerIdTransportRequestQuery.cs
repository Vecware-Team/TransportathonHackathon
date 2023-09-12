using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCustomerId
{
    public class GetByCustomerIdTransportRequestQuery : IRequest<List<GetByCustomerIdTransportRequestResponse>>
    {
        public Guid CustomerId { get; set; }
    }
}
