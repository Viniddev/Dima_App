using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/createTransaction", HandleAsync)
            .WithName("Create: Transaction")
            .WithSummary("Create a new Transaction")
            .WithDescription("Create a new Transaction")
            .Produces<BaseResponse<Transaction?>>()
            .WithOrder(1);

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromBody] CreateTransactionRequest request, ClaimsPrincipal user)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateTransaction(request);
            if (result.IsSuccess)
            {
                return Results.Created($"{result.Data?.Id}", result);
            }

            return Results.BadRequest(result);
        }
    }
}
