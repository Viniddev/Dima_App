using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Response;

namespace Dima.Api.Endpoints.Categories
{
    public class GetCategoryByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Categories: Get category by id")
            .WithSummary("Get category by id")
            .WithDescription("Get category by id")
            .Produces<BaseResponse<Category?>>()
            .WithOrder(4);

        private static async Task<IResult> HandleAsync( ICategoryHandler handler, long id)
        {
            var result = await handler.GetCategoryByIdAsync(id);
            if (result.IsSuccess) 
            {
                return Results.Ok(result.Data);
            }
            
            return Results.BadRequest(result.Data);
        }
    }
}
