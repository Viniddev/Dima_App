using Dima.Core.Enums;
using Dima.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Request.Transactions
{
    public class UpdateTransactionRequest : BaseRequest
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Invalid Title")]
        [MaxLength(80, ErrorMessage = "Length not supported for title")]
        public string Title { get; set; } = string.Empty;


        [Required(ErrorMessage = "Invalid Type")]
        public ETransactionType Type { get; set; }

        public DateTime PaydOrRecivedAt { get; set; }
        public decimal Amount { get; set; }

        public long CategoryId { get; set; }
    }
}
