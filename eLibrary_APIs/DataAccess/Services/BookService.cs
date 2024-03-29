﻿using eLibrary_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace eLibrary_APIs.DataAccess.Services
{
    public class BookService : IBookService
    {
        private readonly ApiDbContext _context;

        public BookService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books
                .Include( b => b.Reviews )
                .Include( b => b.Genre )
                .ToListAsync();
        }

        public async Task<Book> GetBookById(string Id)
        {
            var books = await GetAllBooks();
            return books.FirstOrDefault(book => book.Id == Id)!;
        }

        public async Task<IEnumerable<Book>> SearchForBook(string searchTerm)
        {
            return (await GetAllBooks())
                .Where(
                book => book.Title.ToLower().Contains(searchTerm.ToLower()) || 
                book.Description.ToLower().Contains(searchTerm.ToLower()) ||
                book.Author.ToLower().Contains(searchTerm.ToLower()) ||
                book.Isbn == searchTerm
                ).ToList();
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
