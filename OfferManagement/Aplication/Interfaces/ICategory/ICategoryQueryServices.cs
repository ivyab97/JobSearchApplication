using Aplication.DTO.Response;

namespace Aplication.Interfaces.ICategory
{
    public interface ICategoryQueryServices
    {
        Task<IList<CategoryResponse>> GetCategories();

        Task<bool> CategoriesExist(IList<int> categories);

        Task<CategoryResponse> GetCategoryById(int id);

    }
}
