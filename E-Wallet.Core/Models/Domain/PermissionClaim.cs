using System.Security.Claims;

namespace EWallet.Core.Models.Domain
{
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
