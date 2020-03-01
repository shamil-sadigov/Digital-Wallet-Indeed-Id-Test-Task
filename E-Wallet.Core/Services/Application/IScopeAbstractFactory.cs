using EWallet.Core.Models.Domain;

namespace EWallet.Core.Services.Application
{
    public interface IScopeAbstractFactory
    {
        public (Scope Scope, ScopeClaim Claim) ForAccountCreate();
        public (Scope Scope, ScopeClaim Claim) ForAccountReplenish();
        public (Scope Scope, ScopeClaim Claim) ForAccountWithdraw();
        public (Scope Scope, ScopeClaim Claim) ForAccountTransfer();
        public (Scope Scope, ScopeClaim Claim) ForWalletState();
        public (Scope Scope, ScopeClaim Claim) ForFullScope();

    }
}   
