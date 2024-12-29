using Dima.Api.Data;
using Dima.Api.Endpoints;
using Dima.Api.Handlers;
using Dima.Api.Models;
using Dima.Core.Handlers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

//essa config do "n.FullName" serve para que o nosso swagger n�o se confunda
//quando estiver lidando com entidades ou classes que estejam sendo recebidas
//por parametro e que tem o mesmo nome

builder.Services.AddSwaggerGen(x => 
{
    x.CustomSchemaIds(n => n.FullName);
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Dima.Api",
        Version = "v1"
    });
});


//precisa ser adicionado nessa ordem
builder.Services
    .AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();

builder.Services.AddAuthorization();

//aqui identificamos o identity como dependencia
builder.Services
    .AddIdentityCore<AplicationUser>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints(); //pra que ja crie o api endpoint


builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

builder.Services.AddEndpointsApiExplorer();
app.MapGet("/", () => new { message = "OK" });
app.MapEndpoints();

app.MapGroup("v1/Identity")
    .WithTags("Identity")
    .MapIdentityApi<AplicationUser>();

app.Run();
