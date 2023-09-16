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
            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            Claim? claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserType");

            if (roleClaims.Count <= 0 || roleClaims == null) throw new UnauthorizedException("Unauthorized user");

            if (roleClaims.Contains("Admin") && claim?.Value == "Admin")
                return await next();

            bool isNotMatchedARoleClaimWithRequestRoles = roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)).IsNullOrEmpty();
            if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationDeniedException("You are not authorized.");

            TResponse response = await next();
            return response;
        }
    }
}
