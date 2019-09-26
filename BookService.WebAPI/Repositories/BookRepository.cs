using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository
    {
        private BookServiceContext db;
        public BookRepository(BookServiceContext context)
        {
            db = context;
        }
        public List<Book> List()
        {
            // return a list of books with all Book-properties
            return db.Books.Include(x => x.Publisher).Include(x => x.Author).ToList();
        }

        public List<BookBasic> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only)
            return db.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToList();
        }

        public BookDetail GetById(int id)
        {
            var book = db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefault(b => b.Id == id);

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