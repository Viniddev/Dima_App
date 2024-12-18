using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Request.Categories
{
    public class CreateCategoryRequest : BaseRequest
    {
        //Data Annotations
        [Required(ErrorMessage = "Invalid Title")]
        [MaxLength(80, ErrorMessage = "Length not supported for title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Invalid Description")]
        public string Description { get; set; } = string.Empty;
    }
}

