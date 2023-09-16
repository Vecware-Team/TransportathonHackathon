using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Update
{
    public class UpdateCarrierCommand : IRequest<UpdatedCarrierResponse>, ITransactionalRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid CompanyId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
