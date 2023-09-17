using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using Core.Security.Constants;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Update
{
    public class UpdateTransportRequestCommand : IRequest<UpdatedTransportRequestResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid TransportTypeId { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public string PlaceSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public string[] Roles => new string[] { RoleConstants.Admin };
        public Claim[] Claims => new Claim[] { ClaimConstants.AdminClaim };
    }
}
