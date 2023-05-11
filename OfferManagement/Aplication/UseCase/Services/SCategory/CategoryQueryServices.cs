using Aplication.DTO.Response;
using Aplication.Interfaces.ICategory;

namespace Aplication.UseCase.Services.SCategory
{
    public class CategoryQueryServices : ICategoryQueryServices
    {
        private readonly ICategoryQuery _query;

        public CategoryQueryServices(ICategoryQuery query)
        {
            _query = query;
        }

        public async Task<bool> CategoriesExist(IList<int> categories)
        {
            foreach (var id in categories)
            {
                if (await _query.GetCategory(id)==null)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<CategoryResponse> GetCategoryById(int id)
        {
            var category = await _query.GetCategory(id);

            if (category == null)
            {
                return null;
            }

            return new CategoryResponse
            {
                Id = category.CategoryId,
                Name = category.Name
            };
        }

        public async Task<IList<CategoryResponse>> GetCategories()
        {
            var categories = await _query.GetCategoriesList();
            var response = new List<CategoryResponse>();

            foreach (var item in categories)
            {
                response.Add(new CategoryResponse()
                {
                    Id = item.CategoryId,
                    Name = item.Name
                });     
            }
            return response;
        }
    }
}
