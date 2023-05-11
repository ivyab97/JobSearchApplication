using Aplication.Interfaces.IOfferCategory;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class OfferCategoryCommand : IOfferCategoryCommand
    {
        private readonly AppDbContext _context;

        public OfferCategoryCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> InsertOfferCategory(OfferCategory offerCategory)
        {
            await _context.AddAsync(offerCategory);
            await _context.SaveChangesAsync();

            var category = await _context.Category
                .FirstOrDefaultAsync(ci => ci.CategoryId == offerCategory.CategoryId);

            return category;
        }

        public async Task<bool> RemoveOfferCategory(Guid offerId, int categoryId)
        {
            var offerCategory = _context.OfferCategory.SingleOrDefault(oc=>oc.OfferId==offerId && oc.CategoryId == categoryId);

            if (offerCategory == null)
            {
                return false;
            }

            offerCategory.Status = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
