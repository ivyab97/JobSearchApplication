using Domain.Entities;

namespace Aplication.Interfaces.IOffer
{
    public interface IOfferQuery
    {
        Task<Offer> GetOffer(Guid id);

        Task<IList<Offer>> GetOffersListByFilters(string? description, int? companyId, int? provinceId, int page, string order);

    }
}
