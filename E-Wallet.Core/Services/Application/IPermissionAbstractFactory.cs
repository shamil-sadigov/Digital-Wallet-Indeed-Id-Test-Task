using EWallet.Core.Models.Domain;

namespace EWallet.Core.Services.Application
{
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
