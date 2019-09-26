using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository
    {
        private BookServiceContext db;
        public PublisherRepository(BookServiceContext context)
        {
            db = context;
        }
        public List<Publisher> List()
        {
            // return a list of publishers with all Publisher-properties
            return db.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return db.Publishers.FirstOrDefault(x => x.Id == id);
        }
    }
}