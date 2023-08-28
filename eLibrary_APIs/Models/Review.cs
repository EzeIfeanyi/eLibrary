using eLibrary_APIs.Models.Enums;

namespace eLibrary_APIs.Models;

public class Review: BaseEntity
{
    public string BookId { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public Rating Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public Book Book { get; set; }
}