using eLibrary.Models;
using eLibrary.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly UserManager<User> _userManager;

        public BookController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> AddBook()
        {
            var user = await _userManager.GetUserAsync(User);

            //if (!await _userManager.IsInRoleAsync(user, "admin") )
            //{
            //    RedirectToAction("Index", "Home");
            //}

            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddBook(BookViewModel model)
        {
            return View();
        }
    }
}
