using ApiStore.DTOs;
using ApiStore.Models;
using AutoMapper;

namespace ApiStore.Mappings
{       
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            //Models -> DTO
            CreateMap<Product, ProductResponse>();
            CreateMap<Category, CategoryResponse>();
             CreateMap<Order, OrderResponse>();

            //DTO -> Models
            CreateMap<ProductRequest, Product>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<OrderRequest, Order>();

        }
    }
}
