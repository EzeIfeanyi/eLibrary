using AutoMapper;
using eLibrary_APIs.DataAccess;
using eLibrary_APIs.DataAccess.Services;
using eLibrary_APIs.Models;
using eLibrary_APIs.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto model)
        {
            var book = _mapper.Map<BookDto, Book>(model);

            await _bookService.AddBookAsync(book);

            return Ok();
        }

        [HttpGet("AllItem")]
        public async Task<IActionResult> GetAllItem()
        {
            return Ok(await _bookService.GetAllBooks());
        }


    }
}
