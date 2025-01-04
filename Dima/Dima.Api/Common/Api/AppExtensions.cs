using Dima.Api.Endpoints;
using Dima.Api.Models;

namespace Dima.Api.Common.Api
{
    public static class AppExtensions
    {
        public static void AddSwaggerDevExtensions(this WebApplication app) 
        {
            //adiciona extensões pro swagger em ambiente de dev
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }

        public static void AddAppSecurity(this WebApplication app) 
        {
            //necessariamente passar nessa ordem para que o app compreenda
            //authenticação e os perfis necessarios 
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public static void AddAppInfrastructure(this WebApplication app) 
        {
            //mapeamento para endpoints e identificação do versionamento do app
            app.MapEndpoints();

            app.MapGroup("v1/Identity")
                .WithTags("Identity")
                .MapIdentityApi<AplicationUser>();
        }
    }
}
