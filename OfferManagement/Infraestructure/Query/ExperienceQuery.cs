using Aplication.Interfaces.IExperience;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class ExperienceQuery : IExperienceQuery
    {
        private readonly AppDbContext _context;

        public ExperienceQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Experience> GetExperience(int id)
        {
            var experience = await _context.Experience
                .FirstOrDefaultAsync(e => e.ExperienceId == id);

            return experience;
        }

        public async Task<IList<Experience>> GetExperiencesList()
        {
            return await _context.Experience
                .ToListAsync();
        }
    }
}
