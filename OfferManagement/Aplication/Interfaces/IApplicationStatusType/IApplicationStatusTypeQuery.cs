using Domain.Entities;

namespace Aplication.Interfaces.IApplicationStatusType
{
    public interface IApplicationStatusTypeQuery
    {
        Task<IList<ApplicationStatusType>> GetApplicationStatusTypeList();
        Task<ApplicationStatusType> GetApplicationStatusType(int id);
    }
}
