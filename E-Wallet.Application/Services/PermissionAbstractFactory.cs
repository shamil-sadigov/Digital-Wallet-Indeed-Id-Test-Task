using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;

namespace EWallet.Aplication.Services
{
    public class PermissionAbstractFactory: IPermissionAbstractFactory
    {
        public Permission ForAccountCreate()
              => new Permission(name: PermissionConstants.AccountCreate,
                              permissionClaim: new PermissionClaim(PermissionConstants.AccountCreate, allowed: true));

        public Permission ForAccountReplenish()
              => new Permission(name: PermissionConstants.AccountReplenish,
                              permissionClaim: new PermissionClaim(PermissionConstants.AccountReplenish, allowed: true));

        public Permission ForAccountTransfer()
              => new Permission(name: PermissionConstants.AccountTransfer,
                              permissionClaim: new PermissionClaim(PermissionConstants.AccountTransfer, allowed: true));

        public Permission ForAccountWithdraw()
              => new Permission(name: PermissionConstants.AccountWithdraw,
                              permissionClaim: new PermissionClaim(PermissionConstants.AccountWithdraw, allowed: true));

        public Permission ForFullPermission()
              => new Permission(name: PermissionConstants.FullPermission,
                              permissionClaim: new PermissionClaim(PermissionConstants.FullPermission, allowed: true));

        public Permission ForWalletState()
              => new Permission(name: PermissionConstants.WalletState,
                              permissionClaim: new PermissionClaim(PermissionConstants.WalletState, allowed: true));
    }
}