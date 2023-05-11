using Aplication.DTO.Response;
using Aplication.Interfaces.IApplicationStatusType;

namespace Aplication.UseCase.Services.SApplicationStatusType
{
    public class ApplicationStatusTypeQueryServices : IApplicationStatusTypeQueryServices
    {
        private readonly IApplicationStatusTypeQuery _query;

        public ApplicationStatusTypeQueryServices(IApplicationStatusTypeQuery query)
        {
            _query = query;
        }

        public async Task<IList<ApplicationStatusTypeResponse>> GetApplicationStatusTypes()
        {
            var statusTypes = await _query.GetApplicationStatusTypeList();
            var response = new List<ApplicationStatusTypeResponse>();

            foreach (var item in statusTypes)
            {
                response.Add(new ApplicationStatusTypeResponse()
                {
                    Id = item.ApplicationStatusTypeId,
                    Name = item.Name
                });
            }
            return response;
        }

        public async Task<ApplicationStatusTypeResponse> GetApplicationStatusTypeById(int id)
        {
            var statusType = await _query.GetApplicationStatusType(id);

            if (statusType == null)
            {
                return null;
            }

            return new ApplicationStatusTypeResponse
            {
                Id = statusType.ApplicationStatusTypeId,
                Name = statusType.Name
            };
        }
    }
}
