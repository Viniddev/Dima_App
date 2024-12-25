using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class CreateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/createCategory", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Create a new Category")
            .WithDescription("Create a new Category")
            .Produces<BaseResponse<Category?>>()
            .WithOrder(1);

        private static async Task<IResult> HandleAsync(ICategoryHandler handler, [FromBody] CreateCategoryRequest request) 
        {
            var result = await handler.CreateCategoryAsync(request);
            if (result.IsSuccess) 
            {
                return Results.Created($"{result.Data?.Id}", result);
            }
            
            return Results.BadRequest(result);
        }
    }
}
