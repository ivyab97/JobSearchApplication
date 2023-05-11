using Aplication.DTO.Request;
using Aplication.DTO.Response;
using Aplication.Interfaces.ICategory;
using Aplication.Interfaces.IClient;
using Aplication.Interfaces.IExperience;
using Aplication.Interfaces.IOffer;
using Aplication.Interfaces.IStudyLevel;
using Microsoft.AspNetCore.Mvc;

namespace OfferManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferCommandServices _offerCommandServices;
        private readonly IOfferQueryServices _offerQueryServices;
        private readonly ICategoryQueryServices _categoryQueryServices;
        private readonly IExperienceQueryServices _experienceQueryServices;
        private readonly IStudyLevelQueryServices _studyLevelQueryServices;
        private readonly IClientGeorefArApiServices _apiUbicaciones;


        public OfferController(IOfferCommandServices offerCommandServices, IOfferQueryServices offerQueryServices, ICategoryQueryServices categoryQueryServices, IClientGeorefArApiServices apiUbicaciones, IExperienceQueryServices experienceQueryServices, IStudyLevelQueryServices studyLevelQueryServices)
        {
            _offerQueryServices = offerQueryServices;
            _offerCommandServices = offerCommandServices;
            _categoryQueryServices = categoryQueryServices;
            _experienceQueryServices = experienceQueryServices;
            _studyLevelQueryServices = studyLevelQueryServices;
            _apiUbicaciones = apiUbicaciones;
        }

        [HttpPost]

        [ProducesResponseType(typeof(OfferResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> AddOffer(OfferRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Check that the data entered is valid." }) { StatusCode = 400 };
            }

            if (!await _experienceQueryServices.ExperienceExists(request.ExperienceId))
            {
                return new JsonResult(new BadRequest { message = "Incorrect experience ID." }) { StatusCode = 400 };
            }

            if (!await _studyLevelQueryServices.StudyLevelExists(request.StudyLevelId))
            {
                return new JsonResult(new BadRequest { message = "Incorrect studyLevel ID." }) { StatusCode = 400 };
            }

            if (!await _apiUbicaciones.ValidateProvince(request.ProvinceId))
            {
                return new JsonResult(new BadRequest { message = "Incorrect province ID." }) { StatusCode = 400 };
            }

            if (!await _apiUbicaciones.ValidateCity(request.ProvinceId, request.CityId))
            {
                return new JsonResult(new BadRequest { message = "Incorrect City ID." }) { StatusCode = 400 };
            }

            if (!await _categoryQueryServices.CategoriesExist(request.Categories))
            {
                return new JsonResult(new BadRequest { message = "Enter existing category IDs." }) { StatusCode = 400 };
            }

            var result = await _offerCommandServices.CreateOffer(request);

            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpDelete("{id}")]

        [ProducesResponseType(typeof(OfferResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOffer(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Check that the data entered is valid." }) { StatusCode = 400 };
            }

            var result = await _offerCommandServices.DeleteOffer(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Offer not found, verify ID." }) { StatusCode = 404 };
            }

            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{id}")]

        [ProducesResponseType(typeof(OfferResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOfferById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Check that data the entered is valid." }) { StatusCode = 400 };
            }

            var result = await _offerQueryServices.GetOfferById(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Offer not found." }) { StatusCode = 404 };
            }

            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet]

        [ProducesResponseType(typeof(IList<OfferResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOffers(string? description, int? companyId, int? provinceId, int page = 1, string order = "DESC")
        {
            if (page == 0 || page == null)
            {
                return new JsonResult(new BadRequest { message = "<page> field can only receive int." }) { StatusCode = 400 };
            }

            if (companyId != null && companyId is string)
            {
                return new JsonResult(new BadRequest { message = "<companyId> field can only receive int or null" }) { StatusCode = 400 };
            }

            if (provinceId != null && provinceId is string)
            {
                return new JsonResult(new BadRequest { message = "<provinceId> field can only receive int or null" }) { StatusCode = 400 };
            }

            if (order.ToUpper() != "DESC" && order.ToUpper() != "ASC")
            {
                return new JsonResult(new BadRequest { message = "<order> value is invalid." }) { StatusCode = 400 };

            }

            var ofertas = await _offerQueryServices.GetOffersListByQueries(description, companyId, provinceId, page, order);

            return new JsonResult(ofertas) { StatusCode = 200 };
        }
    }
}
