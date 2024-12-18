using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Request
{
    public abstract class BaseRequest
    {
        [Required(ErrorMessage = "User id must valid")]
        public string UserId { get; set; } = string.Empty;
    }
}
