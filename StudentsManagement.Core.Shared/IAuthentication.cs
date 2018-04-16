using System.Threading.Tasks;

namespace StudentsManagement.Core.Shared
{
    public interface IAuthentication : IInitializer
    {
        Task<bool> LogoutProcess();
        Task<bool> LoginProcess(string email, string password, bool remember);
        Task<bool> RegisterProcess(string email, string password);
    }
}
