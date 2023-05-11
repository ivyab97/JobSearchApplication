using Aplication.DTO.Response;
using Aplication.Interfaces.ICategory;
using Microsoft.AspNetCore.Mvc;

namespace OfferManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryQueryServices _queryServices;

        public CategoryController(ICategoryQueryServices queryServices)
        {
            _queryServices = queryServices;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Verify the ID entered." }) { StatusCode = 400 };
            }

            var result = await _queryServices.GetCategoryById(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Category not found." }) { StatusCode = 404 };
            }

            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet]
        [ProducesResponseType(typeof(IList<CategoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _queryServices.GetCategories();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
