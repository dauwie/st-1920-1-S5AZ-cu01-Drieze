using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository : Repository<Publisher>
    {
        public PublisherRepository(BookServiceContext context) : base(context)
        {

        }
    }
}