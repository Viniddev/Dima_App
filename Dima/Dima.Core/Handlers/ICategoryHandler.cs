using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;

namespace Dima.Core.Handlers;

public interface ICategoryHandler : IGenericHandler<Category>
{
    Task<BaseResponse<Category>> CreateCategoryAsync(CreateCategoryRequest request);
    Task<BaseResponse<Category>> UpdateCategoryAsync(UpdateCategoryRequest request);
}
