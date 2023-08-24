using AutoMapper;
using eLibrary.Models;
using eLibrary.Models.Entities;

namespace eLibrary
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SignUpViewModel, User>()
                .ForMember(user => user.Email, o => o.MapFrom(s => s.Email))
                .ForMember(user => user.UserName, o => o.MapFrom(s => s.Email));
        }
    }
}
