namespace eLibrary_APIs.Models
{
    public class BookCategory : BaseEntity
    {
        public string BookId { get; set; }
        public Category Category { get; set; }
    }
}
