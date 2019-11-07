using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.WebAPI.Data;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository : MappingRepository<Book>
    {
        public BookRepository(BookServiceContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<BookBasic>> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only) using AutoMapper
            return await db.Books
            .ProjectTo<BookBasic>(mapper.ConfigurationProvider)
            .OrderBy(b => b.Title)
            .ToListAsync();

        }

        public async Task<List<Book>> GetAllInclusive()
        {
            return await db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<BookDetail> GetDetailById(int id)
        {
            return mapper.Map<BookDetail>(
                await db.Books
                        .Include(b => b.Author)
                        .Include(b => b.Publisher)
                        .FirstOrDefaultAsync(b => b.Id == id)
            );
        }

        public async Task<List<BookStatistics>> ListStatistics()
        {
            return await db.Books
                    .Include(b => b.Ratings)
                    .Where(b => b.Ratings.Count > 0)
                    .ProjectTo<BookStatistics>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }
        public override async Task<Book> GetById(int id)
        {
            return await db.Books
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}