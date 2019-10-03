using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(BookServiceContext context) : base(context)
        {
        }

        public async Task<List<BookBasic>> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only)
            return await db.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToListAsync();
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
            var book = await db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);

            return new BookDetail
            {
                Id = book.Id,
                AuthorId = book.Author.Id,
                AuthorName = $"{book.Author.FirstName} {book.Author.LastName}",
                FileName = book.FileName,
                ISBN = book.ISBN,
                NumberOfPages = book.NumberOfPages,
                Price = book.Price,
                PublisherId = book.Publisher.Id,
                PublisherName = book.Publisher.Name,
                Title = book.Title,
                Year = book.Year
            };
        }
    }
}