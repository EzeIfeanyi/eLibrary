using eLibrary.Models.Entities;
using eLibrary.Services;

namespace eLibrary.Models;

public class BookViewModel
{
    public IEnumerable<Book> books { get; set; }
}
