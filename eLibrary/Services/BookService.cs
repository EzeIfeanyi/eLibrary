using eLibrary.Models;
using eLibrary.Models.Entities;
using eLibrary.Models.Enums;

namespace eLibrary.Services
{
    public class BookService : DataServices, IBookService
    {
        public BookService(HttpClient client, IConfiguration config) : base(client, config)
        {
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var address = "/Book/all";

            var result = await MakeRequest<IEnumerable<Book>, string>(MethodType.Get, address, null);

            if (result != null)
                return result;

            return new List<Book>();
        }

        public async Task<bool> AddNewBookAsync(AddBookRequestViewModel entity)
        {
            var address = "/Book/add";

            var result = await MakeRequest<ResponseObject<string, string>, AddBookRequestViewModel>(MethodType.Post, address, entity);

            if (result != null)
                return true;

            return false;
        }

        public async Task<bool> UpdateBookAsync(string id, Book entity)
        {
            var address = $"/Book/update/{id}";

            var result = await MakeRequest<ResponseObject<string, string>, Book>(MethodType.Put, address, entity);

            if (result != null)
                return true;
            return false;
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            var address = $"/Book/delete/{id}";

            var result = await MakeRequest<ResponseObject<string, string>, string>(MethodType.Delete, address, "");

            if (result != null) return true;
            return false;
        }
    }
}
