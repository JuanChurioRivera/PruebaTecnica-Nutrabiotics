using AutoMapper;
using PruebaTenicaTodos.Models;
using PruebaTenicaTodos.Dto;

namespace PruebaTenicaTodos.Helper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Todo,TodoDto>();
            CreateMap<TodoDto, Todo>();
        }
    }
}
