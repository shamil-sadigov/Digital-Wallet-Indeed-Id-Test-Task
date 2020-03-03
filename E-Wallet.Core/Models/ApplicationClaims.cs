using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models
{
    public class ApplicationClaims
    {
        public const string UserId = "UserId";
        public const string WalletId = "WalletId";
        public const string Email = "Email";

        public static class Permissions
        {
            public const string CanCreateAccount = "account-create";
            public const string CanReplenishAccount = "account-replenish";
            public const string CanWithdrawFromAccount = "account-withdraw";
            public const string CanTransferBetweenAccounts = "accounts-transfer";
            public const string CanViewWalletStateAndOperations = "wallet-state";
            public const string AllPermissionsAllowed = "all-permissions";
        }
    }
}
