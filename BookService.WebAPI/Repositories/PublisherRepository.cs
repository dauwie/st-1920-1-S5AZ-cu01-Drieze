using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories.Base;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository : Repository<Publisher>
    {
        public PublisherRepository(BookServiceContext context) : base(context)
        {

        }
    }
}