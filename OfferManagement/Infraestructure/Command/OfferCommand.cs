using Aplication.Interfaces.IOffer;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class OfferCommand : IOfferCommand
    {
        private readonly AppDbContext _context;

        public OfferCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Offer> InsertOffer(Offer Offer)
        {
            await _context.AddAsync(Offer);
            await _context.SaveChangesAsync();

            var offerWithPlusData = await _context.Offer
                .Include(e => e.Experience)
                .Include(ne => ne.StudyLevel)
                .FirstOrDefaultAsync(o => o.OfferId==Offer.OfferId);

            return offerWithPlusData;
        }

        public async Task<Offer> RemoveOffer(Guid id)
        {
            var offer = await _context.Offer
                .Include(o => o.Experience)
                .Include(o => o.StudyLevel)
                .Include(o => o.OfferCategory)
                .ThenInclude(oc => oc.Category)
                .FirstOrDefaultAsync(o => o.OfferId == id && o.Status == true);

            if (offer != null)
            {
                offer.Status = false;
                await _context.SaveChangesAsync();
            }
            
            return offer;
        }

    }
}
