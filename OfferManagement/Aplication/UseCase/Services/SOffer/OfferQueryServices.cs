using Aplication.DTO.Response;
using Aplication.Interfaces.IOffer;

namespace Aplication.UseCase.Services.SOffer
{
    public class OfferQueryServices : IOfferQueryServices
    {
        private readonly IOfferQuery _query;

        public OfferQueryServices(IOfferQuery query)
        {
            _query = query;
        }

        public async Task<OfferResponse> GetOfferById(Guid id)
        {
            var offer = await _query.GetOffer(id);

            if (offer==null)
            {
                return null;
            }

            var categories = new List<OfferCategoryResponse>();

            foreach (var item in offer.OfferCategory)
            {
                categories.Add(new OfferCategoryResponse
                {
                    CategoryId = item.Category.CategoryId,
                    Name = item.Category.Name
                });
            }

            return new OfferResponse
            {
                OfferId = offer.OfferId,
                CompanyId = offer.CompanyId,
                Title = offer.Title,
                Description = offer.Description,
                Salary = offer.Salary,
                Experience = new ExperienceResponse
                {
                    Id = offer.Experience.ExperienceId,
                    Name = offer.Experience.Name
                },
                ProvinceId = offer.ProvinceId,
                CityId = offer.CityId,
                StudyLevel = new StudyLevelResponse
                {
                    Id = offer.StudyLevel.StudyLevelId,
                    Name = offer.StudyLevel.Name
                },
                Date = offer.Date.ToString(),
                Categories = categories
            };
        }

        public async Task<IList<OfferResponse>> GetOffersListByQueries(string? description, int? compandyId, int? provinceId, int page, string date)
        {
            var offers = await _query.GetOffersListByFilters(description, compandyId, provinceId, page, date);
            var response = new List<OfferResponse>();

            foreach (var offer in offers)
            {
                response.Add(new OfferResponse
                {
                    OfferId = offer.OfferId,
                    CompanyId = offer.CompanyId,
                    Title = offer.Title,
                    Description = offer.Description,
                    Salary = offer.Salary,
                    Experience = new ExperienceResponse
                    {
                        Id = offer.Experience.ExperienceId,
                        Name = offer.Experience.Name
                    },
                    ProvinceId = offer.ProvinceId,
                    CityId = offer.CityId,
                    StudyLevel = new StudyLevelResponse
                    {
                        Id = offer.StudyLevel.StudyLevelId,
                        Name = offer.StudyLevel.Name
                    },
                    Date = offer.Date.ToString(),
                    Categories = offer.OfferCategory.Select(oc => new OfferCategoryResponse
                    {
                        CategoryId = oc.Category.CategoryId,
                        Name = oc.Category.Name
                    }).ToList()
                });
            }
            return response;
        }
    }
}
