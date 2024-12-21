using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Request.GenericRequests;
using Dima.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class CategoryHandler : GenericHandler<Category>, ICategoryHandler
{
    public CategoryHandler(AppDbContext context) : base(context)
    {
    }

    public async Task<BaseResponse<Category?>> CreateCategoryAsync(CreateCategoryRequest request)
    {
        try
        {
            Category category = new()
            {
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId,
            };

            await _dbSet.AddAsync(category);
            await _context.SaveChangesAsync();

            return new BaseResponse<Category?>(category);
        }
        catch (DbUpdateException)
        {
            //serilog
            throw;
        }
    }

    public async Task<BaseResponse<Category?>> UpdateCategoryAsync(UpdateCategoryRequest request)
    {
        Category? categoria = await _dbSet.Where(x => x.Id == request.Id && x.Active && x.UserId == request.UserId).FirstOrDefaultAsync();

        if (categoria != null)
        {
            categoria.UpdateValues();

            if (!string.IsNullOrEmpty(request.Description))
                categoria.Description = request.Description;

            if (!string.IsNullOrEmpty(request.Title))
                categoria.Title = request.Title;

            _dbSet.Update(categoria);
            await _context.SaveChangesAsync();

            return new BaseResponse<Category?>(categoria);
        }
        else
        {
            return new BaseResponse<Category?>(null, "Couldn't make the update", 500);
        }
    }


    //essa é uma forma utilizada pra consistir e manter o principio da segregação de interface (solid)
    //mas no momento vou manter a implementação completa mesmo 

    //public async Task<BaseResponse<Category>> DeleteAsync(DeleteEntityRequest request)
    //{
    //    return await DeleteCategoryAsync(request);
    //}
}
