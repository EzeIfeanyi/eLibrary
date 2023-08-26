namespace eLibrary_APIs.Models
{
    public class Review : BaseEntity
    {
        public string UserId { get; init; }
        public string BookId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
