namespace BookService.Lib.Models
{
    public class Rating : EntityBase
    {
        public int ReaderId { get; set; }

        public Reader Reader { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Score { get; set; }

        public Rating(int id, int readerId, int bookId, int score)
        {
            Id = id;
            ReaderId = readerId;
            BookId = bookId;
            Score = score;
        }
    }
}
