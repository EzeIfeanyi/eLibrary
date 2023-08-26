namespace eLibrary_APIs.Models
{
    public class BookCategory
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string BookId { get; set; }
        public Category Category { get; set; }
    }
}
