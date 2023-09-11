using MediatR;

namespace TransportathonHackathon.Application.Features.Carriers.Queries.GetById
{
    public class GetByIdCarrierQuery : IRequest<GetByIdCarrierResponse>
    {
        public Guid EmployeeId { get; set; }

    }
}
