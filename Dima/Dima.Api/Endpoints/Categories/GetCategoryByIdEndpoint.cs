using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class GetCategoryByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/getCategoryById/{id}", HandleAsync)
            .WithName("Categories: Get category by id")
            .WithSummary("Get category by id")
            .WithDescription("Get category by id")
            .Produces<BaseResponse<Category?>>()
            .WithOrder(4);

        private static async Task<IResult> HandleAsync(ICategoryHandler handler, long Id)
        {
            var request = new GetCategoryByIdRequest() 
            {
                UserId = "Def",
                Id = Id,
            };

            var result = await handler.GetCategoryByIdAsync(request);
            if (result.IsSuccess) 
            {
                return Results.Ok(result);
            }
            
            return Results.BadRequest(result);
        }
    }
}
