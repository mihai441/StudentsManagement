using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using StudentsManagement.Domain;
using StudentsManagement.Core.Shared;
using StudentManagement.Core.Shared;

namespace StudentManagement.Authentication
{
    class AuthenticationServices : IAuthentication
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ILogger<AuthenticationServices> _logger;

        public AuthenticationServices(IPersistence persist, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void Configure(IApplicationBuilder builder)
        {
            throw new System.NotImplementedException();
        }


        public void Initialize(IServiceCollection collection)
        {
        }

        public async Task<bool> LoginProcess(string email, string password, bool remember)
        {

            var result = await _signInManager.PasswordSignInAsync(email, password, remember, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<bool> LogoutProcessAsync()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<bool> RegisterProcess(string email, string password)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            return result.Succeeded;
        }
    }
}
