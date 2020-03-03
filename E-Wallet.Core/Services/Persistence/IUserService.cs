using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    /// <summary>
    /// Service that enables you to work with User
    /// </summary>
    public interface IUserService
    {
        Task<(User user, string errorMessage)> RegisterUserAsync(UserRegistrationRequest request);
        Task<User> FindByEmail(string email);
        Task<bool> PasswordValid(User user, string password);
    }

}