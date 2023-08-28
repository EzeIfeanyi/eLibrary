using eLibrary_APIs.Models.Enums;

namespace eLibrary_APIs.Models.DTOs
{
    public class ReviewDto
    {
        public string BookId { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
