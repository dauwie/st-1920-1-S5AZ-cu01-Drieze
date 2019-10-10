using System.Collections.Generic;
using System.Threading.Tasks;
using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebAPI.Repositories
{
    public class RatingRepository : Repository<Rating>
    {
        public RatingRepository(BookServiceContext context) : base(context)
        {
        }

        public async Task<List<Rating>> GetAllInclusive()
        {
            return await GetAll().Include(r => r.Reader).Include(r => r.Book).ToListAsync();
        }
    }
}