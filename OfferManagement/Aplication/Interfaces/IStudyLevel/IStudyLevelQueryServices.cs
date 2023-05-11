using Aplication.DTO.Response;

namespace Aplication.Interfaces.IStudyLevel
{
    public interface IStudyLevelQueryServices
    {
        Task<IList<StudyLevelResponse>> GetStudyLevels();

        Task<bool> StudyLevelExists(int id);

        Task<StudyLevelResponse> GetStudyLevelById(int id);
    }
}
