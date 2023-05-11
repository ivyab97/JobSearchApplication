using Aplication.DTO.Request;
using Aplication.DTO.Response;
using Aplication.Interfaces.IOffer;
using Aplication.Interfaces.IOfferCategory;
using Domain.Entities;

namespace Aplication.UseCase.Services.SOffer
{
    public class OfferCommandServices : IOfferCommandServices
    {
        private readonly IOfferCommand _offerCommand;
        private readonly IOfferCategoryCommandServices _offerCategoryCommandServices;
        public OfferCommandServices(IOfferCommand command, IOfferCategoryCommandServices offerCategoryCommandServices)
        {
            _offerCommand = command;
            _offerCategoryCommandServices = offerCategoryCommandServices;
        }

        public async Task<OfferResponse> CreateOffer(OfferRequest dto)
        {
            var offer = new Offer
            {
                OfferId = Guid.NewGuid(),
                CompanyId = dto.CompanyId,
                Title = dto.Title,
                Description = dto.Description,
                Salary = dto.Salary,
                ExperienceId = dto.ExperienceId,
                ProvinceId = dto.ProvinceId,
                CityId = dto.CityId,
                StudyLevelId = dto.StudyLevelId,
                Date = DateTime.Now,
                Status = true
            };

            offer = await _offerCommand.InsertOffer(offer);

            var offerCategoryRequest = new OfferCategoryRequest
            {
                OfferId = offer.OfferId,
                Categories = dto.Categories
            };

            var offerCategoriesResponse = await _offerCategoryCommandServices.CreateOfferCategory(offerCategoryRequest);


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
                Categories = offerCategoriesResponse
            };
        }

        public async Task<OfferResponse> DeleteOffer(Guid id)
        {
            var offer = await _offerCommand.RemoveOffer(id);

            if (offer==null)
            {
                return null;
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
                Categories = offer.OfferCategory.Select(oc => new OfferCategoryResponse
                {
                    CategoryId = oc.Category.CategoryId,
                    Name = oc.Category.Name
                }).ToList()
            };
        }
    }
}
