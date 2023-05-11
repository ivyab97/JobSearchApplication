using Domain.Entities;

namespace Aplication.Interfaces.ICategory
{
    public interface ICategoryQuery
    {
        Task<IList<Category>> GetCategoriesList();
        Task<Category> GetCategory(int id);
    }
}
