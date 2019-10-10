using BookService.WebAPI.Data;
using BookService.WebAPI.Models;

namespace BookService.WebAPI.Repositories
{
    public class ReaderRepository : Repository<Reader>
    {
        public ReaderRepository(BookServiceContext context) : base(context)
        {
        }
    }
}