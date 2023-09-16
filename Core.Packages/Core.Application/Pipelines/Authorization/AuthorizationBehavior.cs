using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Core.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.User is null || _httpContextAccessor.HttpContext.User?.Claims is null)
                throw new UnauthorizedException();

            if (_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(e => e.Type == ClaimTypes.NameIdentifier) is null)
                throw new UnauthorizedException();

            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            List<Claim>? claims = _httpContextAccessor.HttpContext.User.Claims?.ToList();
            Claim? claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserType");

            if (roleClaims.Contains("Admin") && claim?.Value == "Admin")
                return await next();

            bool isNotMatchedARoleClaimWithRequestRoles = roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)).IsNullOrEmpty();
            bool isNotMatchedAClaimWithRequestClaims = claims.FirstOrDefault(claim => request.Claims.Any(c => c.Type == claim.Type && c.Value == claim.Value)) == null;

            if (isNotMatchedAClaimWithRequestClaims && isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationDeniedException("You are not authorized.");

            TResponse response = await next();
            return response;
        }
    }
}
