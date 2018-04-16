using Microsoft.AspNetCore.Identity;
using StudentsManagement.Domain;
using StudentsManagement.Core.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentsManagement.Core
{
    class AuthenticationServices : IInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ILogger<AuthenticationServices> _logger;

        public AuthenticationServices(IPersistence persist)
        {

            _userManager = new UserManager<ApplicationUser>(new UserStore((DbContext)persist.GetStorageContext())); 
            //_signInManager = new SignInManager<ApplicationUser>();
         
        }

        public void Configure(IApplicationBuilder builder)
        {
            throw new System.NotImplementedException();
        }


        public void Initialize(IServiceCollection collection)
        {
        }

        public async Task<int> LoginPost(string email, string password, bool remember)
        {

            var result =await _signInManager.PasswordSignInAsync(email, password, remember, lockoutOnFailure: false);
            
            if (result.Succeeded)

            {
                _logger.LogInformation(0,"User logged in.");
                return 0;
            }
            if (result.RequiresTwoFactor)
            {
                _logger.LogError(1,"Two Factor Requirement");
                return 1;
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning(2,"User account locked out.");
                return 2;
            }
            else
            {
                _logger.LogError(3,"Invalid login attempt.");
                return 3;
            }
        }

        public async System.Threading.Tasks.Task<int> LoginWith2faCheckUser()
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return -1;
            }
            return 1;
        }

        public async System.Threading.Tasks.Task<int> LoginWith2faPostAsync(string authenticatorCode, bool rememberMe, bool rememberMachine)
        {
            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode,rememberMe,rememberMachine);
            if (result.Succeeded)
                return 0;
            if (result.IsLockedOut)
                return 1;
            return 2;
        }

    }
}
