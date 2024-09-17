using ApiStore.DTOs;
using ApiStore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Services.Categories
{
    public class CategoryServices : ICategoryServices
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper _IMapper;

        public CategoryServices(OnlineShopContext context, IMapper iMapper)
        {
            _context = context;
            _IMapper = iMapper;
        }

        public async Task<int> DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return -1;
            }

            _context.Categories.Remove(category);

            return await _context.SaveChangesAsync();
        }

        public async Task<CategoryResponse> GetCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            var categoryResponse = _IMapper.Map<Category, CategoryResponse>(category);
            return categoryResponse;
        }

        public async Task<int> PostCategory(CategoryRequest categoryRequest)
        {
            var category = _IMapper.Map<CategoryRequest, Category>(categoryRequest);

            await _context.Categories.AddAsync(category);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutCategory(int categoryId, CategoryRequest categoryRequest)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return -1; // o lanzar una excepción
            }

            // Actualizar la categoría con los nuevos valores
            category.Nombre = categoryRequest.Nombre;

            _context.Categories.Update(category);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryResponse>> GetCategorys()
        {
            var categories = await _context.Categories.ToListAsync();

            var categoryList = _IMapper.Map<List<Category>, List<CategoryResponse>>(categories);
            return categoryList;
        }
    }
}
