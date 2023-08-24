using AutoMapper;
using eLibrary.Data;
using eLibrary.Models;
using eLibrary.Models.Entities;
using eLibrary.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly eLibraryDbContext _context;

        public AccountController(
            IMapper mapper,
            ILogger<AccountController> logger,
            IAccountService accountService,
            eLibraryDbContext context
            )
        {
            _mapper = mapper;
            _logger = logger;
            _accountService = accountService;
            _context = context;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(SignInViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
            
            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _accountService.SignInAsync(user, model.Password);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid) return View(ModelState);

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("Password Mismatch", "ConfirmPassword is different from Password");
                return View(model);
            }

            var user = _mapper.Map<SignUpViewModel, User>(model);

            var isRegister = await _accountService.SignUpAsync(user, model.Password);

            return isRegister ? RedirectToAction("SignIn", "Account") : View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _accountService.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
