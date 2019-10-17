using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;

namespace BookService.WebAPI.Repositories
{
    public class ReaderRepository : Repository<Reader>
    {
        public ReaderRepository(BookServiceContext context) : base(context)
        {
        }
    }
}