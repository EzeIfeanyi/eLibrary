using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook()
        {
            return View();
        }
    }
}
