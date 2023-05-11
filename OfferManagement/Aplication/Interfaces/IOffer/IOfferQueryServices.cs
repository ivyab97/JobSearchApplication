using Aplication.DTO.Response;

namespace Aplication.Interfaces.IOffer
{
    public interface IOfferQueryServices
    {
        Task<OfferResponse> GetOfferById(Guid id);

        Task<IList<OfferResponse>> GetOffersListByQueries(string? description, int? compandyId, int? provinceId, int page, string date);
    }
}
