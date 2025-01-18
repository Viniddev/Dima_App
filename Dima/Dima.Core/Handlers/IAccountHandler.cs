using Dima.Core.Request.Account;
using Dima.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Handlers
{
    public interface IAccountHandler
    {
        Task<BaseResponse<string>> LoginAsync(LoginAndRegisterRequest login);
        Task<BaseResponse<string>> RegisterAsync(LoginAndRegisterRequest login);
        Task LogoutAsync();
    }
}
