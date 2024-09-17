using ApiStore.DTOs;

namespace ApiStore.Services.Categories
{
    public interface ICategoryServices
    {
        Task<int> PostCategory(CategoryRequest category);

        Task<List<CategoryResponse>> GetCategorys();

        Task<CategoryResponse> GetCategory(int categoryId);

        Task<int> PutCategory(int categoryId, CategoryRequest category);

        Task<int> DeleteCategory(int categoryId);
    }
}
