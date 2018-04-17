using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Domain;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentsManagement.Core.Shared
{
    public interface IAuthentication : IInitializer
    {
        Task<bool> LogoutProcess();
        Task<bool> LoginProcess(string email, string password, bool remember);
        Task<bool> RegisterProcess(string email, string password);
        Task<bool> ExternalLoginCallBackAsync();
        Task<bool> ExternalLogicConfirmationAsync(string email);
        AuthenticationProperties ExternalLogin(string provider, string redirectUrl);
        Task<ApplicationUser> Index(ClaimsPrincipal user);
        Task<bool> ProfileUpdateAsync(ClaimsPrincipal claimsPrincipalUser, string modelEmail, string modelPhoneNumber);
        Task<bool> CheckPasswordData(ClaimsPrincipal claimsPrincipalUser);
        Task<bool> ChangePassword(ClaimsPrincipal claimsPrincipalUser, string oldPassword, string newPassword);
        Task<bool> SetPasswordAsync(ClaimsPrincipal claimsPrincipalUser, string newPassword);

    }
}
