﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/", HandleAsync)
            .WithName("Categories: Delete Category")
            .WithSummary("Delete Category")
            .WithDescription("Delete Category")
            .Produces<BaseResponse<Category?>>()
            .WithOrder(2);

        private static async Task<IResult> HandleAsync( ICategoryHandler handler, [FromBody] DeleteCategoryRequest request) 
        {
            var result = await handler.DeleteCategoryAsync(request);
            if (result.IsSuccess) 
            {
                return Results.Ok(result.Data);
            }
            
            return Results.BadRequest(result.Data);
        }
    }
}