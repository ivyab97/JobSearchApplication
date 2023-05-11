using Aplication.DTO.Response;
using Aplication.Interfaces.IExperience;

namespace Aplication.UseCase.Services.SExperience
{
    public class ExperienceQueryServices : IExperienceQueryServices
    {
        private readonly IExperienceQuery _query;

        public ExperienceQueryServices(IExperienceQuery query)
        {
            _query = query;
        }

        public async Task<bool> ExperienceExists(int id)
        {
            if (await _query.GetExperience(id) == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ExperienceResponse> GetExperienceById(int id)
        {
            var experience = await _query.GetExperience(id);

            if (experience == null)
            {
                return null;
            }

            return new ExperienceResponse
            {
                Id = experience.ExperienceId,
                Name = experience.Name
            };
        }

        public async Task<IList<ExperienceResponse>> GetExperiences()
        {
            var experiences = await _query.GetExperiencesList();
            var response = new List<ExperienceResponse>();

            foreach (var item in experiences)
            {
                response.Add(new ExperienceResponse
                {
                    Id = item.ExperienceId,
                    Name = item.Name
                });
            }
            return response;
        }
    }
}
