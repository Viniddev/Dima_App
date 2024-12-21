using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Categories;
using Dima.Core.Request.GenericRequests;
using Dima.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Controllers.V1
{
    [ApiController]
    [Route("/v1")]
    public class CategoryController(ICategoryHandler Handler) : ControllerBase
    {
        /// <summary>
        /// Cria uma nova categoria.
        /// </summary>
        /// <param name="Request">O objeto contendo os dados para criação da categoria.</param>
        /// <returns>Retorna a categoria criada ou um erro de validação.</returns>
        [HttpPost]
        [Route("/createCategory")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest Request) 
        {
            BaseResponse<Category?> retorno = await Handler.CreateCategoryAsync(Request);

            if (retorno != null)
                return Ok(retorno);
            else
                return BadRequest();
        }

        /// <summary>
        /// Atualiza a categoria.
        /// </summary>
        /// <param name="Request">O objeto contendo os dados para Update.</param>
        /// <returns>Retorna a categoria atualizada ou um erro de execução.</returns>
        [HttpPut]
        [Route("/updateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryRequest Request)
        {
            BaseResponse<Category?> retorno = await Handler.UpdateCategoryAsync(Request);

            if (retorno != null)
                return Ok(retorno);
            else
                return BadRequest();
        }

        /// <summary>
        /// Deleta uma categoria.
        /// </summary>
        /// <param name="Request">O objeto encapsula o id da categoria que queremos deletar </param>
        /// <returns>Retorna a categoria deletada ou um erro de execução.</returns>
        [HttpDelete]
        [Route("/deleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteEntityRequest Request)
        {
            BaseResponse<Category?> retorno = await Handler.DeleteCategoryAsync(Request);

            if (retorno != null)
                return Ok(retorno);
            else
                return BadRequest();
        }

        /// <summary>
        /// Captura uma categoria pelo Id.
        /// </summary>
        /// <param name="Request"> Contém o id da categoria que desejamos.</param>
        /// <returns>Retorna a categoria desejada ou um erro de validação.</returns>
        [HttpGet]
        [Route("/getCategoryById/{Request}")]
        public async Task<IActionResult> GetCategoryByIdAsync(long Request)
        {
            BaseResponse<Category?> retorno = await Handler.GetCategoryByIdAsync(Request);

            if (retorno != null)
                return Ok(retorno);
            else
                return BadRequest();
        }

        /// <summary>
        /// Retorna todas as categorias criadas.
        /// </summary>
        /// <returns>Retorna todas as categorias criadas ou um erro de validação.</returns>
        [HttpPut]
        [Route("/getAllCategories")]
        public async Task<IActionResult> GetAllCategoriesAsync([FromBody] GetAllEntitiesRequest Request)
        {
            PagedResponse<List<Category>> retorno = await Handler.GetAllCategoryAsync(Request);

            if (retorno != null)
                return Ok(retorno);
            else
                return BadRequest();
        }
    }
}
