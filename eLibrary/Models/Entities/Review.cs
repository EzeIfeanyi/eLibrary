namespace eLibrary.Models.Entities
{
    public class Review
    {
        public string BookId { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Book Book { get; set; }
    }
}
