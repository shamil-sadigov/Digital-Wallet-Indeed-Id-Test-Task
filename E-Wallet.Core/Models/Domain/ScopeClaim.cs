using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace E_Wallet.Core.Models.Domain
{
    public class ScopeClaim:IEntity<string>
    {
        public string Id { get; set; }
        public string Permission { get; set; }
        public bool Allowed { get; set; }


        public byte ScopeId { get; set; }
        public Scope Scope { get; set; }


        public ScopeClaim()
        {

        }

        public ScopeClaim(string permission, bool allowed)
        {
            ScopeType = scopeType;
            Allowed = allowed;
        }


        public static explicit operator Claim(ScopeClaim scopeClaim)
        {
            return new Claim(scopeClaim.Permission, scopeClaim.Allowed.ToString());
        }
    }
}
