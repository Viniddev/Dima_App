
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Request
{
    public abstract class BaseRequest
    {
        [Required(ErrorMessage = "User id must valid")]
        public string UserId { get; set; } = string.Empty;
    }
}
