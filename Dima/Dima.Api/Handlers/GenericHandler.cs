using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.GenericRequests;
using Dima.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class GenericHandler<T> : IGenericHandler<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericHandler(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<BaseResponse<T>> GetCategoryByIdAsync(long id)
    {
        var entity = await _dbSet.AsNoTracking().Where(x => x.Id == id && x.Active == true).FirstOrDefaultAsync();

        if (entity != null)
        {
            return new BaseResponse<T>(entity);
        }
        else
        {
            throw new NullReferenceException("Id not found");
        }
    }

    public async Task<BaseResponse<T>> DeleteCategoryAsync(DeleteEntityRequest request)
    {
        var entity = await _dbSet.AsNoTracking().Where(x => x.Id == request.Id && x.Active == true).FirstOrDefaultAsync();

        if (entity != null)
        {
            entity.DisableEntity();

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return new BaseResponse<T>(entity);
        }
        else
        {
            throw new NullReferenceException("Id not found");
        }
    }

    public async Task<BaseResponse<List<T>>> GetAllCategoryAsync()
    {
        List<T> listEntity = _dbSet.AsNoTracking().Where(x => x.Active == true).ToList();

        return new BaseResponse<List<T>>(listEntity);
    }
}
