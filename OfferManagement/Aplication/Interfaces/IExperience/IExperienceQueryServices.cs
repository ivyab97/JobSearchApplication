using Aplication.DTO.Response;

namespace Aplication.Interfaces.IExperience
{
    public interface IExperienceQueryServices
    {
        Task<IList<ExperienceResponse>> GetExperiences();

        Task<bool> ExperienceExists(int id);

        Task<ExperienceResponse> GetExperienceById(int id);
    }
}
