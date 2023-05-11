using Aplication.DTO.Response;
using Aplication.Interfaces.IExperience;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfferManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceQueryServices _service;

        public ExperienceController(IExperienceQueryServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExperienceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExperienceById(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Verify the ID entered." }) { StatusCode = 400 };
            }
            var result = await _service.GetExperienceById(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Resource not found." }) { StatusCode = 404 };
            }
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ExperienceResponse>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllExperience()
        {
            var result = await _service.GetExperiences();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
