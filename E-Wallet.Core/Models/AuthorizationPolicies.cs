using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using static EWallet.Core.Models.ApplicationClaims;

namespace EWallet.Core.Models
{
    public static class AuthorizationPolicy
    {
        public static class Names
        {
            public const string AccountCreate = "can.create-account";
            public const string AccountReplenish = "can.replenish-account";
            public const string AccountWithdraw = "can.withdraw-from-account";
            public const string TransferBetweenAccounts = "can.transfer-between-accounts";
            public const string ViewWalletStateAndHistory = "can.view-walletState-and-operations-history";
        }

        public  class Configurations
        {
            public static Action<AuthorizationPolicyBuilder> AccountCreationOnly()
                => builder => builder.RequireAssertion(context =>
                {
                    var claim = context.User.Claims.FirstOrDefault(c => c.Type == Permissions.CanCreateAccount
                                                                     || c.Type == Permissions.AllPermissionsAllowed);

                    if (!(claim is null))
                        return claim.Value.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase);

                    return false;
                });

            public static Action<AuthorizationPolicyBuilder> AccountReplenish()
               => builder => builder.RequireAssertion(context =>
               {
                   var claim = context.User.Claims.FirstOrDefault(c => c.Type == Permissions.CanReplenishAccount
                                                                    || c.Type == Permissions.AllPermissionsAllowed);

                   if (!(claim is null))
                       return claim.Value.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase);

                   return false;
               });

            public static Action<AuthorizationPolicyBuilder> AccountWithdraw()
               => builder => builder.RequireAssertion(context =>
               {
                   var claim = context.User.Claims.FirstOrDefault(c => c.Type == Permissions.CanWithdrawFromAccount
                                                                    || c.Type == Permissions.AllPermissionsAllowed);

                   if (!(claim is null))
                       return claim.Value.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase);

                   return false;
               });

            public static Action<AuthorizationPolicyBuilder> TransferBetweenAccounts()
               => builder => builder.RequireAssertion(context =>
               {
                   var claim = context.User.Claims.FirstOrDefault(c => c.Type == Permissions.CanTransferBetweenAccounts
                                                                    || c.Type == Permissions.AllPermissionsAllowed);

                   if (!(claim is null))
                       return claim.Value.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase);

                   return false;
               });

            public static Action<AuthorizationPolicyBuilder> ViewWalletState()
               => builder => builder.RequireAssertion(context =>
               {
                   var claim = context.User.Claims.FirstOrDefault(c => c.Type == Permissions.CanViewWalletStateAndOperations
                                                                    || c.Type == Permissions.AllPermissionsAllowed);

                   if (!(claim is null))
                       return claim.Value.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase);

                   return false;
               });
        }

    }
}
