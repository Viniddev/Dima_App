using Dima.Api.Data;
using Dima.Api.Endpoints;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
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
app.UseSwagger();
app.UseSwaggerUI();

//mapeamento dos endpoints
app.MapGet("/", () => new { message = "OK" });
app.MapEndpoints();

app.Run();
