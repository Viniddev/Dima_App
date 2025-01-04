using Dima.Api.Common.Api;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/logout", Handler)
            .WithName("logout")
            .WithDescription("use logout to the current logged user")
            .WithSummary("use logout to the current logged user")
            .RequireAuthorization();

        public static async Task<IResult> Handler(SignInManager<AplicationUser> signInManeger) 
        {
            await signInManeger.SignOutAsync();
            return Results.Ok();
        }
    }
}
