using EWallet.Core.Models.Domain;

namespace EWallet.Core.Services.Persistence
{
    /// <summary>
    /// Token generator that generates authenticationToken for User
    /// </summary>
    public interface IAuthenticationTokenGenerator : ITokenGenerator<User>
    {

    }
}
