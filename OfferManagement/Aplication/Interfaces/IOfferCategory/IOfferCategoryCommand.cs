using Domain.Entities;

namespace Aplication.Interfaces.IOfferCategory
{
    public interface IOfferCategoryCommand
    {
        public Task<Category> InsertOfferCategory(OfferCategory offerCategory);
        public Task<bool> RemoveOfferCategory(Guid offerId, int categoryId);
    }
}
