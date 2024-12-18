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
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<BaseResponse<Category>> GetCategoryByIdAsync(GetCategoryByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<Category>> DeleteCategoryAsync(DeleteCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<List<Category>>> GetAllCategoryAsync(GetAllCategoriesRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<Category>> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
