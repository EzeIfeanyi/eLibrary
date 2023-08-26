using eLibrary.Models;
using eLibrary.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    [Authorize(Roles = "admin")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<User> _userManager;

        public DashBoardController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var book = new Book
            {

            };



            return View();
        }
    }
}
