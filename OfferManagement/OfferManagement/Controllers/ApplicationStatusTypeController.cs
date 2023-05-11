using Aplication.DTO.Response;
using Aplication.Interfaces.IApplicationStatusType;
using Microsoft.AspNetCore.Mvc;

namespace OfferManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatusTypeController : ControllerBase
    {
        private readonly IApplicationStatusTypeQueryServices _queryServices;

        public ApplicationStatusTypeController(IApplicationStatusTypeQueryServices queryServices)
        {
            _queryServices = queryServices;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicationStatusTypeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetApplicationStatusTypeById(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Verify the ID entered." }) { StatusCode = 400 };
            }

            var result = await _queryServices.GetApplicationStatusTypeById(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Resource not found." }) { StatusCode = 404 };
            }

            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet]
        [ProducesResponseType(typeof(IList<ApplicationStatusTypeResponse>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllApplicationStatusTypes()
        {
            var result = await _queryServices.GetApplicationStatusTypes();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
