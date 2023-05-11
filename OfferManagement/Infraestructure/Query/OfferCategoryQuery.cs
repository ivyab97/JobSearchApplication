using Aplication.Interfaces.IOfferCategory;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class OfferCategoryQuery : IOfferCategoryQuery
    {
        private readonly AppDbContext _context;

        public OfferCategoryQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistOfferCategoryByOfertaId(Guid offerId, IList<int> list)
        {
            var offersCategory = await _context.OfferCategory
                .Include(oc=>oc.Category)
                .Where(oc => oc.OfferId == offerId)
                .ToListAsync();

            foreach (var item in offersCategory)
            {
                if (!list.Contains(item.CategoryId))
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
