namespace BookService.Lib.DTO
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string FileName { get; set; }
        public decimal Price { get; set; }
        public string Year { get; set; }
    }
}