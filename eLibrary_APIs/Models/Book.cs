namespace eLibrary_APIs.Models;

public class Book
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Category { get; set; }
    public string Language { get; set; }
    public string? Isbn { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalCopies { get; set; }
    public int NumOfPages { get; set; }
    public DateTime? PublishedAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
