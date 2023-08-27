using eLibrary_APIs.DataAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("AllItem")]
        public async Task<IActionResult> GetAllItem()
        {
            return Ok(await _bookService.GetAllBooks());
        }
    }
}
