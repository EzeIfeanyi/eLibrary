namespace eLibrary.Models.Entities;

public class Book
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Publisher { get; set; }
    //public IList<Category> Categories { get; set; }
}
