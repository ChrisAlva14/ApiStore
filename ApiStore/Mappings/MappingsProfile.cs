using ApiStore.DTOs;
using ApiStore.Models;
using AutoMapper;

namespace ApiStore.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() {

            //Modelo al -> DTO
            CreateMap<User, UserResponse>();

            // Guardar un Usuario
            //DTO -> Modelo

            CreateMap<UserRequest, User>();

        }
    }
}
