using Domain.Entities;

namespace Aplication.Interfaces.IStudyLevel
{
    public interface IStudyLevelQuery
    {
        Task<IList<StudyLevel>> GetStudyLevelList();
        Task<StudyLevel> GetStudyLevel(int id);
    }
}
