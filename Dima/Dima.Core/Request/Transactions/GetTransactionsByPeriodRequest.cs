﻿using Dima.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Request.Transactions
{
    public class GetTransactionsByPeriodRequest : PagedRequest
    {
        [Required(ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime EndDate { get; set; }
    }
}
