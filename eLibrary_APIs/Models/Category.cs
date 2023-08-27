namespace eLibrary_APIs.Models;

public class Category: BaseEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Genre> Genres { get; set; }
}