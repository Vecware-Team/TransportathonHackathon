using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using Core.Security.Constants;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Create
{
    public class CreateTranslateCommand : IRequest<CreatedTranslateResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public string[] Roles => new string[] { RoleConstants.Admin };
        public Claim[] Claims => new Claim[] { ClaimConstants.AdminClaim };
    }
}
