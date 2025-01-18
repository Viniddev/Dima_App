using Dima.Api.Common.Api;
using System.Security.Claims;
using Dima.Core.Models.Account;

namespace Dima.Api.Endpoints.Identity
{
    public class GetRolesIdentityEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/roles", Handle)
            .RequireAuthorization();

        public static Task<IResult> Handle(ClaimsPrincipal AuthenticatedUser) 
        {
            if (AuthenticatedUser.Identity is null || !AuthenticatedUser.Identity.IsAuthenticated)
                return Task.FromResult(Results.Unauthorized());

            var identity = (ClaimsIdentity)AuthenticatedUser.Identity;
            var roles = identity
                .FindAll(identity.RoleClaimType)
                .Select(c => new RoleClaim
                {
                    Issuer =  c.Issuer,
                    OriginalIssuer = c.OriginalIssuer,
                    Type = c.Type,
                    Value = c.Value,
                    ValueType = c.ValueType
                });

            return Task.FromResult<IResult>(TypedResults.Json(roles));
        }
    }
}
