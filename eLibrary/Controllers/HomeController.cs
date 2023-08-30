using eLibrary.Models;
using eLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eLibrary.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;

    public HomeController(ILogger<HomeController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        ViewBag.ActiveLink = "Home";

        var books = _bookService.GetAllBooks().Result;

        if (books == null) return NotFound("No book in the database");

        return View(books);
    }
            

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}