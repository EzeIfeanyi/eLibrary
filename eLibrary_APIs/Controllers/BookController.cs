using AutoMapper;
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
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {

        }


    }
}
