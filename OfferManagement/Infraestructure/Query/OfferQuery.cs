using Aplication.Interfaces.IOffer;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class OfferQuery : IOfferQuery
    {
        private readonly AppDbContext _context;

        public OfferQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Offer>> GetOffersListByFilters(string? description, int? companyId, int? provinceId, int page, string order)
        {
            var Offers = _context.Offer
                .Include(o => o.Experience)
                .Include(o => o.StudyLevel)
                .Include(o => o.OfferCategory)
                .ThenInclude(oc => oc.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(description))
            {
                Offers = Offers.Where(o => o.Title.Contains(description) || o.Description.Contains(description));
            }

            if (companyId.HasValue)
            {
                Offers = Offers.Where(o => o.CompanyId == companyId);
            }

            if (provinceId.HasValue)
            {
                Offers = Offers.Where(o => o.ProvinceId == provinceId);
            }

            switch (order.ToUpper())
            {
                case "ASC":
                    Offers = Offers.OrderBy(o => o.Date);
                    break;
                case "DESC":
                    Offers = Offers.OrderByDescending(o => o.Date);
                    break;
            }

            return await Offers
                .Skip((page - 1) * 10)
                .Take(10)
                .Where(o => o.Status == true)
                .ToListAsync();
        }

        public async Task<Offer> GetOffer(Guid id)
        {
            var offer = await _context.Offer
                .Include(e => e.Experience)
                .Include(ne => ne.StudyLevel)
                .Include(oc => oc.OfferCategory)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(o => o.OfferId == id && o.Status == true);

            return offer;
        }

    }
}
