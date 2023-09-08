using MediatR;
using TransportathonHackathon.Application.Features.Companies.Commands.Delete;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<DeletedCustomerResponse>
    {
        public Guid AppUserId { get; set; }
    }
}
