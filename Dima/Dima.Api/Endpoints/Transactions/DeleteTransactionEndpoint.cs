using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/deleteTransaction", HandleAsync)
            .WithName("Delete a Transaction")
            .WithSummary("Delete a Transaction")
            .WithDescription("Delete a Transaction")
            .Produces<BaseResponse<Transaction?>>()
            .WithOrder(2);
            

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromBody] DeleteTransactionRequest request)
        {
            var result = await handler.DeleteTransaction(request);
            if (result.IsSuccess)
            {
                return Results.Ok(result.Data);
            }

            return Results.BadRequest(result.Data);
        }
    }
}
