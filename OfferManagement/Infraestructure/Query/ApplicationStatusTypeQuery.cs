using Aplication.Interfaces.IApplicationStatusType;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class ApplicationStatusTypeQuery : IApplicationStatusTypeQuery
    {
        private readonly AppDbContext _context;

        public ApplicationStatusTypeQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ApplicationStatusType>> GetApplicationStatusTypeList()
        {
            var applicationStatusTypes = await _context.ApplicationStatusType.ToListAsync();

            return applicationStatusTypes;
        }

        public async Task<ApplicationStatusType> GetApplicationStatusType(int id)
        {
            var applicationStatusType = await _context.ApplicationStatusType.FindAsync(id);

            return applicationStatusType;
        }
    }
}
