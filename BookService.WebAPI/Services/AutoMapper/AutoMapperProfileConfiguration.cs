using AutoMapper;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using System.Linq;

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

            CreateMap<Publisher, PublisherBasic>();
            CreateMap<Book, BookStatistics>()
                .ForMember(dest => dest.RatingsCount,
                            opts => opts.MapFrom(src => src.Ratings.Count))
                .ForMember(dest => dest.ScoreAverage,
                           opts => opts.MapFrom(src => src.Ratings.Average(r => r.Score)));
        }
    }

}
