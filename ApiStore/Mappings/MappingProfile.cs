<<<<<<< HEAD
using ApiStore.DTOs;
=======
﻿using ApiStore.DTOs;
>>>>>>> 5e183b8 (cambios servicios order detail)
using ApiStore.Models;
using AutoMapper;

namespace ApiStore.Mappings
<<<<<<< HEAD
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

=======
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model -> DTO
            CreateMap<OrderDetail, OrderDetailResponse >();

            // DTO -> Model
            CreateMap<OrderDetailRequest, OrderDetail>();
           
>>>>>>> 5e183b8 (cambios servicios order detail)
        }
    }
}
