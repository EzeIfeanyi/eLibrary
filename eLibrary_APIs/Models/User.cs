using Microsoft.AspNetCore.Identity;

namespace eLibrary_APIs.Models;

public class AppUser: IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";

    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IEnumerable<Book> Books { get; set; }
}