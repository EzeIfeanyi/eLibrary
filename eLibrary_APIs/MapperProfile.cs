using AutoMapper;
using eLibrary_APIs.Models;
using eLibrary_APIs.Models.DTOs;

namespace eLibrary_APIs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookDto, Book>();
        }
    }
}
