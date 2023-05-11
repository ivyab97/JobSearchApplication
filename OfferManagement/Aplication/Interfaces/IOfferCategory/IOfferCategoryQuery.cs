namespace Aplication.Interfaces.IOfferCategory
{
    public interface IOfferCategoryQuery
    {
        Task<bool> ExistOfferCategoryByOfertaId(Guid offerId, IList<int> list);
    }
}
