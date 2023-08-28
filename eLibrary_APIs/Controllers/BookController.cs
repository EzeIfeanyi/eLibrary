using AutoMapper;
using eLibrary_APIs.DataAccess;
using eLibrary_APIs.DataAccess.Services;
using eLibrary_APIs.Models;
using eLibrary_APIs.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly ApiDbContext _context;
        public BookController(IBookService bookService, IMapper mapper, ApiDbContext context)
        {
            _bookService = bookService;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBook([FromBody] BookDto model)
        {
            var book = _mapper.Map<BookDto, Book>(model);

            await _bookService.AddBookAsync(book);

            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllItem()
        {
            return Ok(await _bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book?>> GetBook(string id)
        {
            var book = await _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound("Book does not exist");
            }

            return Ok(book);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBook(string searchTerm)
        {
            return Ok(await _bookService.SearchForBook(searchTerm));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BookDto model)
        {
            var book = await _context.Books.FindAsync(id);

            if (book  != null)
            {
                book = _mapper.Map<BookDto, Book>(model);

                await _bookService.UpdateBook(book);

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound("User not found");

            await _bookService.DeleteBook(book);
            return Ok();
        }


    }
}
