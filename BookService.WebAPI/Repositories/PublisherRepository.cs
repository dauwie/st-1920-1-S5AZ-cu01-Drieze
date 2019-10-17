using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository : MappingRepository<Publisher>
    {
        public PublisherRepository(BookServiceContext context,IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<List<PublisherBasic>> ListBasic()
        {
            return await db.Publishers
            .ProjectTo<PublisherBasic>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}