using Dima.Core.Handlers;
using Dima.Core.Request.Account;
using Dima.Core.Response;
using System.Net.Http.Json;
using System.Text;

namespace Dima.WebApp.Handlers
{
    public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Configuration.HttpClientName);

        public async Task<BaseResponse<string>> LoginAsync(LoginAndRegisterRequest login)
        {
            var response = await _httpClient.PostAsJsonAsync("v1/identity/login?useCookies=true", login);

            return response.IsSuccessStatusCode ?
                new BaseResponse<string>("Login realizado com Sucesso!", "Login realizado com Sucesso!", 200) :
                new BaseResponse<string>(null, "Usuário ou senha inválidos!", (int)response.StatusCode);
        }

        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");

            await _httpClient.PostAsJsonAsync("v1/identity/logout", emptyContent);
        }

        public async Task<BaseResponse<string>> RegisterAsync(LoginAndRegisterRequest login)
        {
            var response = await _httpClient.PostAsJsonAsync("v1/identity/register", login);

            return response.IsSuccessStatusCode ?
                new BaseResponse<string>("Cadastro realizado com sucesso!", "Cadastro realizado com sucesso!", 201) :
                new BaseResponse<string>(null, "Não foi possivel realizar o seu cadastro.", (int)response.StatusCode);
        }
    }
}
