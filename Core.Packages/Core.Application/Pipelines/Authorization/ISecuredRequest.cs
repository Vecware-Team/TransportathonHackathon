using System.Security.Claims;

namespace Core.Application.Pipelines.Authorization
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
        public Claim[] Claims { get; }
    }
}
