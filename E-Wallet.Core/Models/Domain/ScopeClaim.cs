using System.Security.Claims;

namespace EWallet.Core.Models.Domain
{
    public class ScopeClaim : IEntity<string>
    {
        public string Id { get; set; }
        public string Permission { get; set; }
        public bool Allowed { get; set; }


        /// <summary>
        /// Ctor for EF Core
        /// </summary>
        public ScopeClaim()
        {

        }

        public ScopeClaim(string permission, bool allowed)
        {
            Permission = permission;
            Allowed = allowed;
        }


        #region Navigration Properties

        public string ScopeId { get; set; }
        public Scope Scope { get; set; }

        #endregion

        public static explicit operator Claim(ScopeClaim scopeClaim)
        {
            return new Claim(scopeClaim.Permission, scopeClaim.Allowed.ToString());
        }
    }
}
