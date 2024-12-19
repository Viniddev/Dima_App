using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Handlers
{
    public interface ICategoryHandler  // multiple implementations
    {
        Task<BaseResponse<Category>> CreateCategoryAsync(CreateCategoryRequest request);
        Task<BaseResponse<Category>> UpdateCategoryAsync(UpdateCategoryRequest request);
        Task<BaseResponse<Category>> DeleteCategoryAsync(DeleteCategoryRequest request);
        Task<BaseResponse<Category>> GetCategoryByIdAsync(long id);
        Task<BaseResponse<List<Category>>> GetAllCategoryAsync();
    }
}
