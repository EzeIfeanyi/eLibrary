using eLibrary.Models.Entities;
using System.Security.Claims;

namespace eLibrary.Services.IServices
{
    public interface IAccountService
    {
        bool IsSignedIn(ClaimsPrincipal user);
        Task<bool> SignInAsync(User user, string password, bool isPersistent = false, bool isLockedOut = false);
        Task SignOutAsync();
        Task<bool> SignUpAsync(User user, string password);
    }
}