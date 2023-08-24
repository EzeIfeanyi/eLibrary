using AutoMapper;
using eLibrary.Models;
using eLibrary.Models.Entities;

namespace eLibrary
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SignUpViewModel, User>();
        }
    }
}
