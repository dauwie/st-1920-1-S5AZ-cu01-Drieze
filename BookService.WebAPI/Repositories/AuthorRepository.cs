using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(BookServiceContext context) : base(context)
        {

        }

        public async Task<List<AuthorBasic>> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only)
            return await db.Authors.Select(b => new AuthorBasic
            {
                Id = b.Id,
                Name = $"{b.FirstName} {b.LastName}",
            }).ToListAsync();
        }
    }
}