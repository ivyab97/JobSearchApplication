using Aplication.DTO.Response;

namespace Aplication.Interfaces.IApplicationStatusType
{
    public interface IApplicationStatusTypeQueryServices
    {
        Task<IList<ApplicationStatusTypeResponse>> GetApplicationStatusTypes();

        Task<ApplicationStatusTypeResponse> GetApplicationStatusTypeById(int id);
    }
}
