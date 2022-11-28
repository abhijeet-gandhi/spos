using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Veronica.Identity.Models;

namespace Veronica.Identity
{
    public interface IIdentityService
    {
        Task<SignInResult> SignInAsync(string username, string password, bool rememberMe);

        Task<ApplicationUser> FindAsync(string username);

        Task SignOutAsync();
    }

    public class IdentityService : IIdentityService
    {
        private readonly ILogger<IdentityService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(ILogger<IdentityService> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignInAsync(string username, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: true);
        }

        public async Task<ApplicationUser> FindAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}