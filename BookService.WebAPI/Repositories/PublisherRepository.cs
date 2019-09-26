using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Publisher> Update(Publisher publisher)
        {
            try
            {
                db.Entry(publisher).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(publisher.Id))
                {
                    return null;
                }
                else { throw; }
            }
            return publisher;
        }

        private bool PublisherExists(int id)
        {
            return db.Publishers.Any(e => e.Id == id);
        }

        public async Task<Publisher> Add(Publisher publisher)
        {
            db.Publishers.Add(publisher);
            await db.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher> Delete(int id)
        {
            var publisher = await db.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return null;
            }
            db.Publishers.Remove(publisher);
            await db.SaveChangesAsync();
            return publisher;
        }
    }
}