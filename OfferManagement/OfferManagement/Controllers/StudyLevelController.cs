using Aplication.DTO.Response;
using Aplication.Interfaces.IStudyLevel;
using Microsoft.AspNetCore.Mvc;

namespace OfferManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyLevelController : ControllerBase
    {
        private readonly IStudyLevelQueryServices _service;

        public StudyLevelController(IStudyLevelQueryServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudyLevelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudyLevelById(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Verify the ID entered." }) { StatusCode = 400 };
            }
            var result = await _service.GetStudyLevelById(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Resource not found." }) { StatusCode = 404 };
            }
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<StudyLevelResponse>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllStudyLevels()
        {
            var result = await _service.GetStudyLevels();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
