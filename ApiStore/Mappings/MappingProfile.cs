using ApiStore.DTOs;
using ApiStore.Models;
using AutoMapper;

namespace ApiStore.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile() { 

            //Model -> DTO
            CreateMap<Order, OrderResponse>();

            //DTO -> Model
            CreateMap<OrderRequest, Order>();
        
        }
    }
}
