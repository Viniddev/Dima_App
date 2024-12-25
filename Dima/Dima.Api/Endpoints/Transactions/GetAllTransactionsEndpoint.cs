﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

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

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromBody] GetAllTransactionsRequest request)
        {
            var result = await handler.GetAllTransactions(request);
            if (result.IsSuccess)
            {
                return Results.Ok(result.Data);
            }

            return Results.BadRequest(result.Data);
        }
    }
}
