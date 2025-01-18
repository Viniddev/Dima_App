using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Dima.WebApp;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//uso do Microsoft.Extensions.Http
builder.Services.AddHttpClient(Configuration.HttpClientName, opt => 
{
    opt.BaseAddress = new Uri(Configuration.BackEndUrl);
}).AddHttpMessageHandler<string>();

//mudblazor usage
builder.Services.AddMudServices();

await builder.Build().RunAsync();
