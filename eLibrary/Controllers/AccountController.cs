using AutoMapper;
using eLibrary.Data;
using eLibrary.Models;
using eLibrary.Models.Entities;
using eLibrary.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eLibrary.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private readonly IMessanger _messanger;

        public AccountController(
            IMapper mapper,
            ILogger<AccountController> logger,
            IAccountService accountService,
            UserManager<User> userManager,
            IMessanger messanger
            )
        {
            _mapper = mapper;
            _logger = logger;
            _accountService = accountService;
            _userManager = userManager;
            _messanger = messanger;
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            if (_accountService.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            //ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(SignInViewModel model, string ReturnUrl)
        {
            if (_accountService.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
            
            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(ModelState);

            var response = await _accountService.SignInAsync(user, model.Password);

            var returnUrl = !string.IsNullOrEmpty(ReturnUrl);

            return response && returnUrl ? LocalRedirect(ReturnUrl) 
                : RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return isRegister ? RedirectToAction("Login", "Account") : View(model);
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

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);
                // If the user is found AND Email is confirmed
                if ( user != null )
                {
                    // Generate the reset password token
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    // Build the password reset link
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                            new { email = model.Email, token }, Request.Scheme);

                    var body = $@"<h1>Recovery Link</h1>
                                    <p>Hi {user.FirstName}</p> 
                                    <p>Use this link to reset your password</p> {passwordResetLink}";

                    _ = _messanger.Send("Password Reset", model.Email, body, "");

                    ViewData["IsSent"] = true;
                    
                    return View();
                }
                ViewData["IsSent"] = true;
                return View();
            }

            return View(model);
        }

        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Email = email, Token = token };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid || model.Password != model.ConfirmPassword)
                return View(model);

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            var response = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (response != null)
            {

            }
            ViewData["reset"] = true;

            return View();
        }
    }
}
