using System.Security.Claims;

namespace EWallet.Core.Models.Domain
{
    /// <summary>
    /// Claim that represent wether user is allowed to do the action
    /// Example: If user would like to increate account funds, then permissionToken should
    /// be provided inside of which permissionClaim is stored that can be with name = "account-replenish" and Allowed = true
    /// </summary>
    public class PermissionClaim : IEntity<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Allowed { get; set; }


        /// <summary>
        /// Ctor for EF Core
        /// </summary>
        public PermissionClaim()
        {

        }

        public PermissionClaim(string name, bool allowed)
        {
            Name = name;
            Allowed = allowed;
        }


        #region Navigration Properties

        public string PermissionId { get; set; }
        public Permission Permission { get; set; }

        #endregion

        public static explicit operator Claim(PermissionClaim PermissionClaim)
        {
            return new Claim(PermissionClaim.Name, PermissionClaim.Allowed.ToString());
        }
    }
}
