using eLibrary_APIs.Models;

namespace eLibrary_APIs.DataAccess.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
    }
}