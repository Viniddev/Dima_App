using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions
{
    public class GetTransactionsByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/getTransactionsByPeriod", HandleAsync)
            .WithName("Get all Transactions in a determinated range of time")
            .WithDescription("Get all Transactions in a determinated range of time")
            .WithSummary("Get all Transactions in a determinated range of time")
            .Produces<PagedResponse<List<Transaction?>>>()
            .WithOrder(6);

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromBody] GetTransactionsByPeriodRequest request)
        {
            var result = await handler.GetTransactionsByPeriod(request);
            if (result.IsSuccess)
            {
                return Results.Ok(result.Data);
            }

            return Results.BadRequest(result.Data);
        }
    }
}
