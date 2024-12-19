using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Request.GenericRequests;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

//essa config do "n.FullName" serve para que o nosso swagger não se confunda
//quando estiver lidando com entidades ou classes que estejam sendo recebidas
//por parametro e que tem o mesmo nome

builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

//transient ->
//   sempre cria uma nova instancia do category independente de quantas vezes eu chame os metodos em uma mesma requisição

//scoped ->
//   sempre usa a mesma versão por requisição (que nem o addDbContext)

//singleton ->
//   so tem uma instancia por aplicação (possui o mesmo manipulador pra todas as requisicoes independente do usuario)

//--------------------------------------------------------------//

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

//--------------------------------------------------------------//

var app = builder.Build();

app.MapPost(
    "/v1/createCategory",
    ([FromBody] CreateCategoryRequest Request, ICategoryHandler Handler) => Handler.CreateCategoryAsync(Request))
    .WithName("/v1/createCategory")
    .WithSummary("Create a new category")
    .Produces<BaseResponse<Category>>();

app.MapPut(
    "/v1/updateCategory",
    ([FromBody] UpdateCategoryRequest Request, ICategoryHandler Handler) => Handler.UpdateCategoryAsync(Request))
    .WithName("/v1/updateCategory")
    .WithSummary("Update category")
    .Produces<BaseResponse<Category>>();

app.MapPut(
    "/v1/deleteCategory",
    ([FromBody] DeleteEntityRequest Request, ICategoryHandler Handler) => Handler.DeleteCategoryAsync(Request))
    .WithName("/v1/deleteCategory")
    .WithSummary("Delete category")
    .Produces<BaseResponse<Category>>();

app.MapPut(
    "/v1/getCategoryById",
    ([FromBody] long Request, ICategoryHandler Handler) => Handler.GetCategoryByIdAsync(Request))
    .WithName("/v1/categories")
    .WithSummary("Get a category by id")
    .Produces<BaseResponse<Category>>();

app.MapGet(
    "/v1/getAllCategories",
    (ICategoryHandler Handler) => Handler.GetAllCategoryAsync())
    .WithName("/v1/getAllCategories")
    .WithSummary("Get all categories")
    .Produces<BaseResponse<Category>>();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();
