using Dima.Api.Common.Api;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Identity
{
    public class GetRolesIdentityEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/roles", Handle)
            .RequireAuthorization();

        public async static Task<IResult> Handle(ClaimsPrincipal AuthenticatedUser) 
        {
            if (AuthenticatedUser.Identity is null || !AuthenticatedUser.Identity.IsAuthenticated)
                return Results.Unauthorized();

            var identity = (ClaimsIdentity)AuthenticatedUser.Identity;
            var roles = identity
                .FindAll(identity.RoleClaimType)
                .Select(c => new
                {
                    c.Issuer,
                    c.OriginalIssuer,
                    c.Type,
                    c.Value,
                    c.ValueType
                });

            return TypedResults.Json(roles);
        }
    }
}
