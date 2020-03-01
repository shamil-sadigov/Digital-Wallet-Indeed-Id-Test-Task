using System;
using System.Collections.Generic;
using System.Text;

namespace E_Wallet.Core.Models.Domain
{
    public partial class Scope : IEntity<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Scope()
        {
            Claims = new HashSet<ScopeClaim>();
        }

        public Scope(string name):this()
        {
            Name = name;
        }

        public ICollection<ScopeClaim> Claims { get; set; }
    }
}
