using Aplication.DTO.Request;
using Aplication.DTO.Response;

namespace Aplication.Interfaces.IOfferCategory
{
    public interface IOfferCategoryCommandServices
    {
        public Task<IList<OfferCategoryResponse>> CreateOfferCategory(OfferCategoryRequest dto);
        public Task<bool> DeleteOfferCategory(Guid offerId, IList<int> categories);
    }
}
