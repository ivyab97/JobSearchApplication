using Aplication.Interfaces.IStudyLevel;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class StudyLevelQuery : IStudyLevelQuery
    {
        private readonly AppDbContext _context;

        public StudyLevelQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<StudyLevel>> GetStudyLevelList()
        {
            return await _context.StudyLevel
                .ToListAsync();
        }

        public async Task<StudyLevel> GetStudyLevel(int id)
        {
            var studyLevel = await _context.StudyLevel
                .FirstOrDefaultAsync(ne => ne.StudyLevelId == id);
            
            return studyLevel;
        }
    }
}
