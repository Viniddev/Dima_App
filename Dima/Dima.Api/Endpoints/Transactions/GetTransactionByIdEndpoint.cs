using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions
{
    public class GetTransactionByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
       => app.MapGet("/getTransactionById/{Id}", HandleAsync)
           .WithName("Get Transaction by id")
           .WithDescription("Get Transaction by id")
           .WithSummary("Get Transaction by id")
           .Produces<BaseResponse<Transaction?>>()
           .WithOrder(4);

        private static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromQuery] long Id)
        {
            var request = new GetTransactionByIdRequest 
            {
                Id = Id,
                UserId = "vini@123"
            };

            var result = await handler.GetTransactionById(request);
            if (result.IsSuccess)
            {
                return Results.Ok(result);
            }

            return Results.BadRequest(result);
        }
    }
}
