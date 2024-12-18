using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dima.Core.Response
{
    public class PagedResponse<TData> : BaseResponse<TData>
    {
        [JsonConstructor]
        public PagedResponse(TData? data, int totalCount, int pageSize, int currentPage = 1) : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public PagedResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null) : base(data, message, code)
        {  
        }

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}
