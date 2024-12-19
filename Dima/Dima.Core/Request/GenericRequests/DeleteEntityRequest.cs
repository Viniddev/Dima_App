using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Request.GenericRequests
{
    public class DeleteEntityRequest
    {
        [Required(ErrorMessage = "Id must be valid")]
        public long Id { get; set; }
    }
}
