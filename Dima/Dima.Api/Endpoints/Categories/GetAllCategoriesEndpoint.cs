using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/getAllCategories", HandleAsync)
            .WithName("Categories: Get All Categories")
            .WithSummary("Get All Categories")
            .WithDescription("Get All Categories")
            .Produces<PagedResponse<List<Category?>>>()
            .WithOrder(3);

        private static async Task<IResult> HandleAsync( ICategoryHandler handler, [FromBody] GetAllCategoriesRequest request, ClaimsPrincipal user) 
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.GetAllCategoryAsync(request);
            if (result.IsSuccess) 
            {
                return Results.Ok(result);
            }
            
            return Results.BadRequest(result);
        }
    }
}
