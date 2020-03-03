using EWallet.Core.Models.Domain;

namespace EWallet.Core.Services.Application
{
    /// <summary>
    /// Abstract factory that creates Permission with PermissionClaims inside
    /// Basically used for Data seeding
    /// </summary>
    public interface IPermissionAbstractFactory
    {
        public Permission ForAccountCreate();
        public Permission ForAccountReplenish();
        public Permission ForAccountWithdraw();
        public Permission ForAccountTransfer();
        public Permission ForWalletState();
        public Permission ForFullPermission();
    }
}
