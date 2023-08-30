namespace eLibrary.Models.Entities
{
    public class Genre
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Category Category { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
