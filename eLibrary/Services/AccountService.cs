using eLibrary.Models.Entities;
using eLibrary.Services.IServices;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace eLibrary.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountService(
        UserManager<User> userManager,
        SignInManager<User> signInManager
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> SignInAsync(
        User user,
        string password,
        bool isPersistent = false,
        bool isLockedOut = false)
    {
        var loginResponse = await _signInManager
            .PasswordSignInAsync(user, password, isPersistent, isLockedOut);

        if (loginResponse.Succeeded)
        {
            return true;
        }
        return false;
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public bool IsSignedIn(ClaimsPrincipal user)
    {
        return _signInManager.IsSignedIn(user);
    }

    public async Task<bool> SignUpAsync(User user, string password)
    {
        var response = await _userManager.CreateAsync(user, password);
        if (response.Succeeded)
        {
            return true;
        }
        return false;
    }
}
