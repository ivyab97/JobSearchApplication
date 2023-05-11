using Domain.Entities;

namespace Aplication.Interfaces.IOffer
{
    public interface IOfferCommand
    {
        public Task<Offer> InsertOffer(Offer Offer);
        public Task<Offer> RemoveOffer(Guid id);

    }
}
