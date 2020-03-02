using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models.Domain
{
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
