using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class GetAllTransactionsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/getAllTransactions", HandleAsync)
            .WithName("Get all Transactions")
            .WithDescription("Get all Transactions")
            .WithSummary("Get all Transactions")
            .Produces<PagedResponse<List<Transaction?>>>()
            .WithOrder(3);

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromBody] GetAllTransactionsRequest request, ClaimsPrincipal user)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.GetAllTransactions(request);
            if (result.IsSuccess)
            {
                return Results.Ok(result);
            }

            return Results.BadRequest(result);
        }
    }
}
