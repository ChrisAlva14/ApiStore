using ApiStore.DTOs;
using ApiStore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Services.Products
{
    public class ProductServices : IProductServices
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper _IMapper;

        public ProductServices(OnlineShopContext context, IMapper iMapper)
        {
            _context = context;
            _IMapper = iMapper;
        }

        public async Task<int> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return -1;
            }

            _context.Products.Remove(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<ProductResponse> GetProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            // Usa AutoMapper para mapear el producto a ProductResponse
            var productResponse = _IMapper.Map<Product, ProductResponse>(product);
            return productResponse;
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            // Usa AutoMapper para mapear la lista de productos a una lista de ProductResponse
            var productsList = _IMapper.Map<List<Product>, List<ProductResponse>>(products);

            return productsList;
        }

        public async Task<int> PostProduct(ProductRequest product)
        {
            // Mapear ProductRequest a Product
            var productRequest = _IMapper.Map<ProductRequest, Product>(product);

            await _context.Products.AddAsync(productRequest);

            await _context.SaveChangesAsync();

            return productRequest.Id;
        }

        public async Task<int> PutProduct(int productId, ProductRequest product)
        {
            var entitiy = await _context.Products.FindAsync(productId);

            if (entitiy == null)
            {
                return -1;
            }

            entitiy.Nombre = product.Nombre;
            entitiy.Descripcion = product.Descripcion;
            entitiy.Precio = product.Precio;
            entitiy.CategoriaId = product.CategoriaId;
            entitiy.Stock = product.Stock;
            entitiy.Imagen = product.Imagen;

            _context.Products.Update(entitiy);

            return await _context.SaveChangesAsync();
        }
    }
}
