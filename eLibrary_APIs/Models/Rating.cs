namespace eLibrary_APIs.Models
{
    public class Rating : BaseEntity
    {
        public string BookId { get; set; }
        public int NumberOfStar { get; set; }
    }
}
