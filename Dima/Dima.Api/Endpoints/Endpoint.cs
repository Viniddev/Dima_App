using Dima.Api.Common.Api;
using Dima.Api.Endpoints.Categories;
using Dima.Api.Endpoints.Transactions;

namespace Dima.Api.Endpoints
{
    public static class Endpoint
    {
        //extension method quando usamos this
        public static void MapEndpoints(this WebApplication app) 
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("v1/categories")
                .WithTags("Categories")
                .RequireAuthorization()
                .MapEndpoint<CreateCategoryEndpoint>()
                .MapEndpoint<UpdateCategoryEndpoint>()
                .MapEndpoint<DeleteCategoryEndpoint>()
                .MapEndpoint<GetAllCategoriesEndpoint>()
                .MapEndpoint<GetCategoryByIdEndpoint>();

            endpoints.MapGroup("v1/transaction")
                .WithTags("Transactions")
                .RequireAuthorization()
                .MapEndpoint<CreateTransactionEndpoint>()
                .MapEndpoint<UpdateTransactionEndpoint>()
                .MapEndpoint<DeleteTransactionEndpoint>()
                .MapEndpoint<GetAllTransactionsEndpoint>()
                .MapEndpoint<GetTransactionByIdEndpoint>()
                .MapEndpoint<GetTransactionsByPeriodEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
