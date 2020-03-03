using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models
{
    public static class AuthorizationPolicies
    {
        public const string AccountCreateOnly = "Can create new account";
        public const string AccountReplenishOrWithdraw = "Can replenish or withdraw account amount";
    }
}
