namespace EWallet.Core.Services.Persistence
{
    public interface ITokenFactory
    {
        IAuthenticationTokenGenerator UserAuthentication { get; set; }
        IPermissionTokenGenerator PermissiondToken { get; set; }
    }

}
