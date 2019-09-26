using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class AuthorRepository
    {
        private BookServiceContext db;
        public AuthorRepository(BookServiceContext context)
        {
            db = context;
        }
        public List<Author> List()
        {
            // return a list of authors with all Author-properties
            return db.Authors.ToList();
        }

        public List<AuthorBasic> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only)
            return db.Authors.Select(b => new AuthorBasic
            {
                Id = b.Id,
                Name = $"{b.FirstName} {b.LastName}",
            }).ToList();
        }

        public Author GetById(int id)
        {
            return db.Authors.FirstOrDefault(x => x.Id == id);
        }
    }
}