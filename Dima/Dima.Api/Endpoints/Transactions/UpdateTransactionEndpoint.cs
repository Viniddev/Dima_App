using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/updateTransaction", HandleAsync)
            .WithName("Update a Transaction")
            .WithDescription("Update a Transaction")
            .WithSummary("Update a Transaction")
            .Produces<BaseResponse<Transaction?>>()
            .WithOrder(5);

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromBody] UpdateTransactionRequest request)
        {
            var result = await handler.UpdateTransaction(request);
            if (result.IsSuccess)
            {
                return Results.Ok(result);
            }

            return Results.BadRequest(result);
        }
    }
}
