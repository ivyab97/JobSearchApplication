using Aplication.DTO.Request;
using Aplication.DTO.Response;

namespace Aplication.Interfaces.IOffer
{
    public interface IOfferCommandServices
    {
        public Task<OfferResponse> CreateOffer(OfferRequest dto);
        public Task<OfferResponse> DeleteOffer(Guid id);

    }
}
