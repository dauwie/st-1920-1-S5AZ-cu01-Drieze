using AutoMapper;
using BookService.WebAPI.Data;
using BookService.Lib.Models;

namespace BookService.WebAPI.Repositories.Base
{
    public class MappingRepository<T> : Repository<T> where T : EntityBase
    {
        protected readonly IMapper mapper;

        public MappingRepository(BookServiceContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
    }

}
