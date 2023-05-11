using Aplication.DTO.Request;
using Aplication.DTO.Response;
using Aplication.Interfaces.IOfferCategory;
using Domain.Entities;

namespace Aplication.UseCase.Services.SOfferCategory
{
    public class OfferCategoryCommandServices : IOfferCategoryCommandServices
    {
        private readonly IOfferCategoryCommand _command;

        public OfferCategoryCommandServices(IOfferCategoryCommand command)
        {
            _command = command;
        }

        public async Task<IList<OfferCategoryResponse>> CreateOfferCategory(OfferCategoryRequest dto)
        {
            var response = new List<OfferCategoryResponse>();

            foreach (var id in dto.Categories)
            {
                var offerCategory = new OfferCategory
                {
                    CategoryId = id,
                    OfferId = dto.OfferId,
                    Status = true
                };

                var category = await _command.InsertOfferCategory(offerCategory);

                response.Add(new OfferCategoryResponse
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                });
            }
            return response;
        }

        public async Task<bool> DeleteOfferCategory(Guid offerId, IList<int> categories)
        {
            foreach (var id in categories)
            {
                if (!await _command.RemoveOfferCategory(offerId, id))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
