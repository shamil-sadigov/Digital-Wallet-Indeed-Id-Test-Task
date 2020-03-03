using EWallet.Core.Models;
using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using static EWallet.Core.Models.ApplicationClaims;

namespace EWallet.Aplication.Services
{
    public class PermissionAbstractFactory: IPermissionAbstractFactory
    {
        public Permission ForAccountCreate()
              => new Permission(name: Permissions.CanCreateAccount,
                              permissionClaim: new PermissionClaim(Permissions.CanCreateAccount, allowed: true));

        public Permission ForAccountReplenish()
              => new Permission(name: Permissions.CanReplenishAccount,
                              permissionClaim: new PermissionClaim(Permissions.CanReplenishAccount, allowed: true));

        public Permission ForAccountTransfer()
              => new Permission(name: Permissions.CanTransferBetweenAccounts,
                              permissionClaim: new PermissionClaim(Permissions.CanTransferBetweenAccounts, allowed: true));

        public Permission ForAccountWithdraw()
              => new Permission(name: Permissions.CanWithdrawFromAccount,
                              permissionClaim: new PermissionClaim(Permissions.CanWithdrawFromAccount, allowed: true));

        public Permission ForFullPermission()
              => new Permission(name: Permissions.AllPermissionsAllowed,
                              permissionClaim: new PermissionClaim(Permissions.AllPermissionsAllowed, allowed: true));

        public Permission ForWalletState()
              => new Permission(name: Permissions.CanViewWalletStateAndOperations,
                              permissionClaim: new PermissionClaim(Permissions.CanViewWalletStateAndOperations, allowed: true));
    }
}
