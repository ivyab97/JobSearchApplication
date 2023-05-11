using Domain.Entities;

namespace Aplication.Interfaces.IExperience
{
    public interface IExperienceQuery
    {
        Task<IList<Experience>> GetExperiencesList();
        Task<Experience> GetExperience(int id);
    }
}
