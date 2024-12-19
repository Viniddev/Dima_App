using Dima.Core.Models;
using Dima.Core.Request.GenericRequests;
using Dima.Core.Response;

namespace Dima.Core.Handlers;

public interface IGenericHandler<T>
{
    Task<BaseResponse<T>> DeleteCategoryAsync(DeleteEntityRequest request);
    Task<BaseResponse<T>> GetCategoryByIdAsync(long id);
    Task<BaseResponse<List<T>>> GetAllCategoryAsync();
}
