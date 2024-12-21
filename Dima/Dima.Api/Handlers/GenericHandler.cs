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

    public async Task<BaseResponse<T?>> GetCategoryByIdAsync(long id)
    {
        var entity = await _dbSet.AsNoTracking().Where(x => x.Id == id && x.Active == true).FirstOrDefaultAsync();

        if (entity != null)
        {
            return new BaseResponse<T?>(entity, "", 200);
        }
        else
        {
            return new BaseResponse<T?>(null, "category not found", 404);
        }
    }

    public async Task<BaseResponse<T?>> DeleteCategoryAsync(DeleteEntityRequest request)
    {
        var entity = await _dbSet.Where(x => x.Id == request.Id && x.Active == true).FirstOrDefaultAsync();

        if (entity != null)
        {
            entity.DisableEntity();

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return new BaseResponse<T?>(entity, "Successfully deleted", 200);
        }
        else
        {
            return new BaseResponse<T?>(null, "category not found", 404);
        }
    }

    public async Task<PagedResponse<List<T>>> GetAllCategoryAsync(GetAllEntitiesRequest Request)
    {
        try 
        {
            IQueryable<T> query = _dbSet.AsNoTracking()
                .Where(x => x.Active)
                .OrderBy(x=>x.Id);

            List<T> listEntity = await query
                .Skip((Request.PageNumber - 1) * Request.PageSize)
                .Take(Request.PageSize)
                .ToListAsync();

            int total = await query.CountAsync();

            return new PagedResponse<List<T>>(data:listEntity, totalCount: total, pageSize:Request.PageSize, currentPage: Request.PageNumber);
        } catch (Exception) 
        {
            return new PagedResponse<List<T>>(null, 500, "Couldn't make the query");
        }
    }
}
