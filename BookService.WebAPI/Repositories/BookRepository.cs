using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return db.Books.ToList();
        }

        public List<BookBasic> ListBasic()
        {
            return db.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToList();
        }
    }
}
