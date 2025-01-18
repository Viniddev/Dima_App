
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Request.Account
{
    public class LoginAndRegisterRequest
    {
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "A Senha é inválida")]
        public string Password { get; set; } = string.Empty;
    }
}
