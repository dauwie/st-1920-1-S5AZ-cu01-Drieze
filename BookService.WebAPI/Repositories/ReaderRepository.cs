using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories.Base;

namespace BookService.WebAPI.Repositories
{
    public class ReaderRepository : Repository<Reader>
    {
        public ReaderRepository(BookServiceContext context) : base(context)
        {
        }
    }
}