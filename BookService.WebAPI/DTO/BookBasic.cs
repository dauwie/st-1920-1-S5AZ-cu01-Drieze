using BookService.WebAPI.Models;
using System.Collections.Generic;

namespace BookService.WebAPI.DTO
{
    public class BookBasic
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //public int AuthorId { get; set; }
        //public string AuthorFirstName { get; set; }
        //public string AuthorLastName { get; set; }
        //public int PublisherId { get; set; }
        //public string PublisherName { get; set; }
        //public ICollection<Rating> Ratings { get; set; }

    }
}
