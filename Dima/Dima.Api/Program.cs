using Dima.Api.Data;
using Dima.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//essa config do "n.FullName" serve para que o nosso swagger não se confunda
//quando estiver lidando com entidades ou classes que estejam sendo recebidas
//por parametro e que tem o mesmo nome

builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddTransient<Handler>();

//--------------------------------------------------------------//

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

//--------------------------------------------------------------//

var app = builder.Build();

app.MapPost(
    "/v1/categories",
    ([FromBody] Request request, Handler handler) => {  return handler.Handle(request); })
    .WithName("/v1/categories")
    .WithSummary("Create a new category")
    .Produces<Response>();

app.MapPost(
    "/v1/teste",
     ([FromBody] Request request, Handler handler) => { return handler.Handle(request); })
    .WithName("/v1/teste")
    .WithSummary("Produces response by create transactions")
    .Produces<Response>();


app.UseSwagger();
app.UseSwaggerUI();
app.Run();

//--------------------------------------------------------------//

//request
public record Request
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; } = 1;
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}

//response
public record Response 
{
    public string Id { get; set; } = string.Empty;
    public string Resp { get; set; } = string.Empty;
}

//handler
public class Handler(AppDbContext context)
{
    public Response Handle(Request request) 
    {
        var category = new Category() 
        {
            Title = request.Title,
            Description = request.Description
        };

        context.Categories.Add(category);
        context.SaveChanges();

        return new Response()
        {
            Id = request.UserId,
            Resp = request.Title
        };
    }
}