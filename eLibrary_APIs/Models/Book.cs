namespace eLibrary_APIs.Models;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Author { get; set; }
    public string Language { get; set; }
    public string? Isbn { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalCopies { get; set; }
    public int NumOfPages { get; set; }
    public DateTime? PublishedAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<BookGenre> BookGenre { get; set; }
    public ICollection<Rating> Ratings { get; set;}
    public ICollection<Review> Reviews { get; set; }
    public BookCategory BookCategoriess { get; set; }
}
