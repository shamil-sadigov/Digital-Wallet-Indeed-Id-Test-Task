using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    public interface IUserService
    {
        Task RegisterUser(UserRegistrationRequest request);
        Task GetUserToken(UserTokenRequest request);
        Task GetUserAccountScopedToken();
    }


    public interface ITokenFactory<T> 
    {
        string GenerateToken(T entity);
    }


    public interface IAuthenticationTokenFactory : ITokenFactory<User>
    {

    }



    public interface IScopedTokenFactory : ITokenFactory<string[]>
    {

    }



    public interface IAppTokenFactory
    {
        IUserAccessTokenFactory UserTokenFactory { get; set; }
        IScopedTokenFactory ScopedTokenFactory { get; set; }
    }


}
