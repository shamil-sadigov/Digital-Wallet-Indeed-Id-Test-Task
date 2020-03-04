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


        public static void CreateIf<T, TOutput>(this T input, Func<T, bool> del, out TOutput output, TOutput value)
        {
            if (del(input))
                output = value;
            output = default;
        }


        public static void PredicatePassed<Tinput>(this Tinput input, Func<Tinput, bool> predicate, out bool output)
            => output = predicate(input);
        

    }
}
