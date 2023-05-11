using Aplication.Interfaces.ICategory;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly AppDbContext _context;

        public CategoryQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Category
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            return category;
        }

        public async Task<IList<Category>> GetCategoriesList()
        {
            return await _context.Category
                .ToListAsync();
        }

    }
}
