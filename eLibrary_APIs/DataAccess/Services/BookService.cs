using eLibrary_APIs.DataAccess.Repo;
using eLibrary_APIs.Models;

namespace eLibrary_APIs.DataAccess.Services
{
    public class BookService : IBookService
    {
        private readonly IItemRepository<Book> _bookRepo;
        private readonly IItemRepository<BookCategory> _bookCategoryRepo;
        private readonly IItemRepository<Category> _categoryRepo;
        private readonly IItemRepository<Review> _reviewRepo;
        private readonly IItemRepository<Rating> _ratingRepo;

        public BookService(
            IItemRepository<Book> bookRepo, 
            IItemRepository<BookCategory> bookCategoryRepo, 
            IItemRepository<Category> categoryRepo, 
            IItemRepository<Review> reviewRepo, 
            IItemRepository<Rating> ratingRepo)
        {
            _bookRepo = bookRepo;
            _bookCategoryRepo = bookCategoryRepo;
            _categoryRepo = categoryRepo;
            _reviewRepo = reviewRepo;
            _ratingRepo = ratingRepo;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepo.GetAllAsync();
        }
    }
}
