using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookService.Lib.Models
{
    public class Reader : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonIgnore]
        public ICollection<Rating> Ratings { get; set; }

        public Reader(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}