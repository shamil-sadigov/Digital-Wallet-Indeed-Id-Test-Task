using EWallet.Core.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace EWallet.Application.Helper
{
    public static class ExtensionHelpers
    {
        // Return User Id
        public static string GetId(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.FindFirstValue(ApplicationClaims.UserId);
    }
}
