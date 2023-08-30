using eLibrary.Models;
using eLibrary.Models.Entities;

namespace eLibrary.Services
{
    public interface IBookService
    {
        Task<bool> AddNewBookAsync(AddBookRequestViewModel entity);
        Task<bool> DeleteBookAsync(string id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<bool> UpdateBookAsync(string id, Book entity);
    }
}