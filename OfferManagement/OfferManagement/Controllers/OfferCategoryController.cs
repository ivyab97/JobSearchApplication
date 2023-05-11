using Aplication.DTO.Response;
using Aplication.Interfaces.IOfferCategory;
using Microsoft.AspNetCore.Mvc;

namespace OfferManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferCategoryController : ControllerBase
    {
        private readonly IOfferCategoryCommandServices _commandServices;
        private readonly IOfferCategoryQueryServices _queryServices;

        public OfferCategoryController(IOfferCategoryCommandServices commandServices, IOfferCategoryQueryServices queryServices)
        {
            _commandServices = commandServices;
            _queryServices = queryServices;
        }

        [HttpDelete("{offerId}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOfferCategory(Guid offerId, IList<int> categories)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Check that the data entered is valid." }) { StatusCode = 400 };
            }

            if (!await _queryServices.IOfferCategoryExistsInOfferId(offerId, categories))
            {
                return new JsonResult(new BadRequest { message = "Enter existing category IDs." }) { StatusCode = 404 };
            }

            if (!await _commandServices.DeleteOfferCategory(offerId, categories))
            {
                return new JsonResult(new BadRequest { message = "Enter an existing offer ID." }) { StatusCode = 404 };
            }

            return new JsonResult("Deleted categories.") { StatusCode = 200 };
        }
    }
}
