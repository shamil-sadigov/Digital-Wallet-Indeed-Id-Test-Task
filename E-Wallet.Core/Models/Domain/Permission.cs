using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models.Domain
{
    /// <summary>
    /// Represent some scopes based on which User work with account
    /// Example: Permission with name = "account-replenishment" will allow user only to replenish fund on account
    /// and nothing more
    /// You can take a look at ApplicationClaims.Permission to get familiar with the rest of permission names
    /// </summary>
    public partial class Permission : IEntity<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Permission()
        {
            Claims = new HashSet<PermissionClaim>();
        }

        public Permission(string name, PermissionClaim permissionClaim)
        {
            Name = name;
            Claims = new HashSet<PermissionClaim>();
            Claims.Add(permissionClaim);
        }

        public ICollection<PermissionClaim> Claims { get; set; }
    }
}
