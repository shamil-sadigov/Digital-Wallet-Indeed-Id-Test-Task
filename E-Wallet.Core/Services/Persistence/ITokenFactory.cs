namespace EWallet.Core.Services.Persistence
{
    public interface ITokenFactory
    {
        IAuthenticationTokenGenerator UserAuthentication { get; set; }
        IScopedTokenGenerator ScopedToken { get; set; }
    }

}
