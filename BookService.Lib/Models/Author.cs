using System;

namespace BookService.Lib.Models
{
    public class Author : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
