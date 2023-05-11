namespace Aplication.Interfaces.IOfferCategory
{
    public interface IOfferCategoryQueryServices
    {
        Task<bool> IOfferCategoryExistsInOfferId(Guid offerId, IList<int> list);
    }
}
