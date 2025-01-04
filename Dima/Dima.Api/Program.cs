using Dima.Api.Common.Api;
using Dima.Core;

//--------------------------------------------------------------//

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();

builder.AddDocumentation();

builder.AddSecurity();

builder.AddCrossOrigin();

builder.AddDataBaseContext();

builder.AddEndpointInfrastructure();

//--------------------------------------------------------------//

var app = builder.Build();

app.AddAppSecurity();

if(app.Environment.IsDevelopment())
    app.AddSwaggerDevExtensions();

app.UseCors(Configuration.CorsPolicyName);

app.AddAppInfrastructure();

//--------------------------------------------------------------//

app.Run();
