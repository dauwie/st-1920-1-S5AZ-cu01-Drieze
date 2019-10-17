namespace BookService.WebAPI.DTO
{
    public class BookStatistics
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RatingsCount { get; set; }
        public double ScoreAverage { get; set; }
    }
}
