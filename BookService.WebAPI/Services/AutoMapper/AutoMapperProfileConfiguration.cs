using AutoMapper;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;

namespace BookService.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<Book, BookBasic>();
            CreateMap<Book, BookDetail>()
                .ForMember(
                dest => dest.AuthorName,
                opts => opts.MapFrom(
                src => $"{src.Author.LastName} {src.Author.FirstName}"));

        }
    }

}
