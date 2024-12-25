using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/UpdateCategory", HandleAsync)
            .WithName("Categories: Update")
            .WithSummary("Update a Category")
            .WithDescription("Update a Category")
            .Produces<BaseResponse<Category?>>()
            .WithOrder(5);

        private static async Task<IResult> HandleAsync( ICategoryHandler handler, [FromBody] UpdateCategoryRequest request) 
        {
            var result = await handler.UpdateCategoryAsync(request);
            if (result.IsSuccess) 
            {
                return Results.Ok(result.Data);
            }
            
            return Results.BadRequest(result.Data);
        }
    }
}
