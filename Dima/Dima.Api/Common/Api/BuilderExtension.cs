using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Api.Models;
using Dima.Core;
using Dima.Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Common.Api
{
    public static class BuilderExtension
    {
        //isso é um metodo de extensão do Builder
        public static void AddConfiguration(this WebApplicationBuilder builder) 
        {
            //pega a connection string default
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

            Configuration.FrontEndUrl = builder.Configuration.GetConnectionString("FrontEndUrl") ?? string.Empty;
            Configuration.BackEndUrl = builder.Configuration.GetConnectionString("BackEndUrl") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder) 
        {
            //essa config do "n.FullName" serve para que o nosso swagger não se confunda
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

            builder.Services.AddEndpointsApiExplorer();
        }

        public static void AddSecurity(this WebApplicationBuilder builder) 
        {
            //precisa ser adicionado nessa ordem
            builder.Services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            builder.Services.AddAuthorization();
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                x => x.AddPolicy(
                    Configuration.CorsPolicyName,
                    policy => policy.WithOrigins([Configuration.FrontEndUrl, Configuration.BackEndUrl])// identificamos as urls permitidas
                    .AllowAnyHeader() // por meio delas aceitamos todo tipo de cabeçalho
                    .AllowAnyMethod() // por elas aceitamos todos os tipos de metodos http
                    .AllowCredentials() // por elas aceitamos metodos de credencial e autenticação
                )
            );
        }

        public static void AddDataBaseContext(this WebApplicationBuilder builder) 
        {
            //cria o dbContext
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.ConnectionString));
        }

        public static void AddEndpointInfrastructure(this WebApplicationBuilder builder) 
        {
            //aqui identificamos o identity como dependencia
            builder.Services
                .AddIdentityCore<AplicationUser>()
                .AddRoles<IdentityRole<long>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints(); //pra que ja crie o api endpoint

            //transient ->
            //   sempre cria uma nova instancia do category independente de quantas vezes eu chame os metodos em uma mesma requisição

            //scoped ->
            //   sempre usa a mesma versão por requisição (que nem o addDbContext)

            //singleton ->
            //   so tem uma instancia por aplicação (possui o mesmo manipulador pra todas as requisicoes independente do usuario)

            builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
            builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
        }

    }
}
