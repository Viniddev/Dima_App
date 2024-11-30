using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//essa config do "n.FullName" serve para que o nosso swagger não se confunda
//quando estiver lidando com entidades ou classes que estejam sendo recebidas
//por parametro e que tem o mesmo nome

builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddTransient<Handler>();

//--------------------------------------------------------------//

var app = builder.Build();

//request mapping
//get, post, put, delete

//endpoint 
//sao as urls para acesso

app.MapPost(
    "/v1/transactions",
    ([FromBody] Request request, Handler handler) => { handler.Handle(request); })
    .WithName("/v1/transactions/create")
    .WithSummary("Produces response by create transactions")
    .Produces<Response>();

app.MapPost(
    "/v1/teste",
    ([FromBody] Request request) => { new Response() { Resp = "resp" }; })
    .WithName("/v1/transactions/testing")
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
    public string UserId { get; set; } = string.Empty;
}
//response

public record Response 
{
    public string Resp { get; set; } = string.Empty;
}

//handler
public class Handler
{
    public Response Handle(Request request) 
    {
        return new Response()
        {
            Resp = request.Title
        };
    }
}