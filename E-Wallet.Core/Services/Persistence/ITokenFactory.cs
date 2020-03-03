namespace EWallet.Core.Services.Persistence
{
    /// <summary>
    /// TokenFactory that enables you to generate user authenticaiton token and permission token
    /// King of Mediator Pattern
    /// </summary>
    public interface ITokenFactory
    {
        IAuthenticationTokenGenerator UserAuthentication { get; }
        IPermissionTokenGenerator PermissiondToken { get; }
    }

}
