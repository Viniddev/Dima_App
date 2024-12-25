using Dima.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Request.Transactions
{
    public class CreateTransactionRequest : BaseRequest
    {
        [Required(ErrorMessage = "Invalid Title")]
        [MaxLength(80, ErrorMessage = "Length not supported for title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Invalid Type")]
        public ETransactionType Type { get; set; }

        public DateTime PaydOrRecivedAt { get; set; }
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Required a valid Category Id")]
        public long CategoryId { get; set; }
    }
}

