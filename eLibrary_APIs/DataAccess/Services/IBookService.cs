using eLibrary_APIs.Models;

namespace eLibrary_APIs.DataAccess.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(string Id);
        Task<IEnumerable<Book>> SearchForBook(string Title = "", string Description = "", string Author = "", string ISBN = "");
        Task AddBookAsync(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Book book);
    }
}