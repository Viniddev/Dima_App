using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//essa config do "n.FullName" serve para que o nosso swagger n�o se confunda
//quando estiver lidando com entidades ou classes que estejam sendo recebidas
//por parametro e que tem o mesmo nome

builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

//transient ->
//   sempre cria uma nova instancia do category independente de quantas vezes eu chame os metodos em uma mesma requisi��o

//scoped ->
//   sempre usa a mesma vers�o por requisi��o (que nem o addDbContext)

//singleton ->
//   so tem uma instancia por aplica��o (possui o mesmo manipulador pra todas as requisicoes independente do usuario)

//--------------------------------------------------------------//

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

//--------------------------------------------------------------//

var app = builder.Build();

app.MapPost(
    "/v1/categories",
    ([FromBody] CreateCategoryRequest Request, ICategoryHandler Handler) => Handler.CreateCategoryAsync(Request))
    .WithName("/v1/categories")
    .WithSummary("Create a new category")
    .Produces<BaseResponse<Category>>();


app.UseSwagger();
app.UseSwaggerUI();
app.Run();
