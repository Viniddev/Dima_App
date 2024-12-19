using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<BaseResponse<Category>> CreateCategoryAsync(CreateCategoryRequest request)
        {
            try
            {
                Category category = new()
                {
                    Title = request.Title,
                    Description = request.Description,
                    UserId = request.UserId,
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return new BaseResponse<Category>(category);
            }
            catch (DbUpdateException ex)
            {
                //serilog
                throw;
            }
        }

        public async Task<BaseResponse<Category>> GetCategoryByIdAsync(long id)
        {
            Category? categoria = await context.Categories.AsNoTracking().Where(x => x.Id == id && x.Active == true).FirstOrDefaultAsync();

            if (categoria != null)
            {
                return new BaseResponse<Category>(categoria);
            }
            else
            {
                throw new NullReferenceException("Id not found");
            }
        }

        public async Task<BaseResponse<Category>> DeleteCategoryAsync(DeleteCategoryRequest request)
        {
            Category? categoria = await context.Categories.AsNoTracking().Where(x => x.Id == request.Id && x.Active == true).FirstOrDefaultAsync();

            if (categoria != null)
            {
                categoria.Active = false;
                categoria.UpdateDate = DateTime.Now;

                context.Categories.Update(categoria);
                await context.SaveChangesAsync();

                return new BaseResponse<Category>(categoria);
            }
            else
            {
                throw new NullReferenceException("Id not found");
            }
        }

        public async Task<BaseResponse<List<Category>>> GetAllCategoryAsync()
        {
            List<Category> listCategories = context.Categories.AsNoTracking().Where(x => x.Active == true).ToList();

            return new BaseResponse<List<Category>>(listCategories);
        }

        public async Task<BaseResponse<Category>> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            Category? categoria = await context.Categories.AsNoTracking().Where(x => x.Id == request.Id && x.Active == true).FirstOrDefaultAsync();

            if (categoria != null)
            {
                categoria.UpdateDate = DateTime.Now;

                if (!string.IsNullOrEmpty(request.Description))
                    categoria.Description = request.Description;

                if (!string.IsNullOrEmpty(request.Title))
                    categoria.Title = request.Title;

                context.Categories.Update(categoria);
                await context.SaveChangesAsync();

                return new BaseResponse<Category>(categoria);
            }
            else
            {
                throw new NullReferenceException("Id not found");
            }
        }
    }
}
