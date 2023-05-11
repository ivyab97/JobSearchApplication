using Aplication.Interfaces.IOfferCategory;

namespace Aplication.UseCase.Services.SOfferCategory
{
    public class OfferCategoryQueryServices : IOfferCategoryQueryServices
    {
        private readonly IOfferCategoryQuery _query;

        public OfferCategoryQueryServices(IOfferCategoryQuery query)
        {
            _query = query;
        }

        public async Task<bool> IOfferCategoryExistsInOfferId(Guid offerId, IList<int> list)
        {
           return await _query.ExistOfferCategoryByOfertaId(offerId, list);
        }
    }
}
