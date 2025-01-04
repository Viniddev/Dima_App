using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/deleteCategory", HandleAsync)
            .WithName("Categories: Delete Category")
            .WithSummary("Delete Category")
            .WithDescription("Delete Category")
            .Produces<BaseResponse<Category?>>()
            .WithOrder(2);

        private static async Task<IResult> HandleAsync( ICategoryHandler handler, [FromBody] DeleteCategoryRequest request, ClaimsPrincipal user) 
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.DeleteCategoryAsync(request);
            if (result.IsSuccess) 
            {
                return Results.Ok(result);
            }
            
            return Results.BadRequest(result);
        }
    }
}
