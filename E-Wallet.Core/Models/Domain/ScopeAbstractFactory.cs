namespace E_Wallet.Core.Models.Domain
{
    public class ScopeAbstractFactory: IScopeAbstractFactory
    {
        public (Scope Scope, ScopeClaim Claim) ForAccountCreate()
            => (Scope: new Scope(ScopeConstants.AccountCreate),
                Claim: new ScopeClaim(permission: ScopeConstants.AccountCreate, allowed: true));

        public (Scope Scope, ScopeClaim Claim) ForAccountReplenish()
           => (Scope: new Scope(ScopeConstants.AccountReplenish),
               Claim: new ScopeClaim(permission: ScopeConstants.AccountReplenish, allowed: true));

        public (Scope Scope, ScopeClaim Claim) ForAccountWithdraw()
          => (Scope: new Scope(ScopeConstants.AccountWithdraw),
              Claim: new ScopeClaim(permission: ScopeConstants.AccountWithdraw, allowed: true));

        public (Scope Scope, ScopeClaim Claim) ForAccountTransfer()
         => (Scope: new Scope(ScopeConstants.AccountTransfer),
             Claim: new ScopeClaim(permission: ScopeConstants.AccountTransfer, allowed: true));

        public (Scope Scope, ScopeClaim Claim) ForWalletState()
         => (Scope: new Scope(ScopeConstants.WalletState),
             Claim: new ScopeClaim(permission: ScopeConstants.WalletState, allowed: true));

        public (Scope Scope, ScopeClaim Claim) ForFullScope()
         => (Scope: new Scope(ScopeConstants.FullScope),
             Claim: new ScopeClaim(permission: ScopeConstants.FullScope, allowed: true));
    }


    public interface IScopeAbstractFactory
    {
        public (Scope Scope, ScopeClaim Claim) ForAccountCreate();
        public (Scope Scope, ScopeClaim Claim) ForAccountReplenish();
        public (Scope Scope, ScopeClaim Claim) ForAccountWithdraw();
        public (Scope Scope, ScopeClaim Claim) ForAccountTransfer();
        public (Scope Scope, ScopeClaim Claim) ForWalletState();
        public (Scope Scope, ScopeClaim Claim) ForFullScope()

    }
}   
