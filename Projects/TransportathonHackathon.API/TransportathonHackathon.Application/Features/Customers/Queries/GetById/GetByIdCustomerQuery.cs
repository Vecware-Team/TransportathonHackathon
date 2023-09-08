using MediatR;

namespace TransportathonHackathon.Application.Features.Customers.Queries.GetById
{
    public class GetByIdCustomerQuery : IRequest<GetByIdCustomerResponse>
    {
        public Guid AppUserId { get; set; }
    }
}
