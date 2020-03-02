using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    public interface IUserService
    {
        Task<(User user, string errorMessage)> RegisterUserAsync(UserRegistrationRequest request);
        Task GetUserToken(UserTokenRequest request);
        Task GetUserAccountScopedToken();
    }

}