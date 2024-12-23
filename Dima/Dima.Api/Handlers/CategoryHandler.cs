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
            catch (DbUpdateException)
            {
                return new BaseResponse<Category>(null, "Category not found", 500);
            }
        }

        public async Task<BaseResponse<Category>> GetCategoryByIdAsync(long id)
        {
            Category? category = await context.Categories.AsNoTracking().Where(x => x.Id == id && x.Active == true).FirstOrDefaultAsync();

            if (category != null)
            {
                return new BaseResponse<Category>(category);
            }
            else
            {
                return new BaseResponse<Category>(null, "Category not found", 500);
            }
        }

        public async Task<BaseResponse<Category>> DeleteCategoryAsync(DeleteCategoryRequest request)
        {
            Category? category = await context.Categories.Where(x => x.Id == request.Id && x.Active == true && x.UserId == request.UserId).FirstOrDefaultAsync();

            if (category != null)
            {
                category.DisableEntity();

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return new BaseResponse<Category>(category);
            }
            else
            {
                return new BaseResponse<Category>(null, "Could not delete the specified category", 500);
            }
        }

        public async Task<PagedResponse<List<Category>>> GetAllCategoryAsync(GetAllCategoriesRequest request)
        {
            try
            {
                IQueryable<Category> query = context.Categories.AsNoTracking().Where(x => x.Active == true && x.UserId == request.UserId);

                List<Category> listCategories = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                int totalItems = await query.CountAsync();

                return new PagedResponse<List<Category>>(listCategories, totalItems, request.PageSize, request.PageNumber);
            }
            catch (Exception) 
            {
                return new PagedResponse<List<Category>>(null, 500, "Couldn't find any item or a bad request happened");
            }
        }

        public async Task<BaseResponse<Category>> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            Category? category = await context.Categories.Where(x => x.Id == request.Id && x.Active == true && x.UserId == request.UserId).FirstOrDefaultAsync();

            if (category != null)
            {
                category.UpdateValues();

                if (!string.IsNullOrEmpty(request.Description))
                    category.Description = request.Description;

                if (!string.IsNullOrEmpty(request.Title))
                    category.Title = request.Title;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return new BaseResponse<Category>(category);
            }
            else
            {
                return new BaseResponse<Category>(null, "Category couldn't be updated", 500);
            }
        }
    }
}
