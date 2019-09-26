using System.ComponentModel.DataAnnotations;

namespace BookService.WebAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }

        [Display(Name = "#")]
        public int NumberOfPages { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public string FileName { get; set; }

        public decimal Price { get; set; }

        public string Year { get; set; }
    }
}
