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

// --> segundo o chat isso é util pra adicionar as controllers
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();

//isso aqui é pra documentar a api usando o xml
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

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

//removi as minimal apis

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
