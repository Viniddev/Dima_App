using Dima.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Models
{
    public class Transaction : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime? PaidOrReceivedAt { get; set; }
        public ETransactionType Type { get; set; } = ETransactionType.WithDraw;
        public decimal Amount { get; set; } 
        public long CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
    }
}
