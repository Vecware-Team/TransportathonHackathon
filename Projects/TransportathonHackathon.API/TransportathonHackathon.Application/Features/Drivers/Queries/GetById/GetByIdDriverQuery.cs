using MediatR;

namespace TransportathonHackathon.Application.Features.Drivers.Queries.GetById
{
    public class GetByIdDriverQuery : IRequest<GetByIdDriverResponse>
    {
        public Guid EmployeeId { get; set; }
    }
}
