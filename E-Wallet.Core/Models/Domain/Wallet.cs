using System.Collections.Generic;

namespace EWallet.Core.Models.Domain
{
    public class Wallet : IEntity<string>
    {
        public string Id { get; set; }

        public Wallet()
        {
            Accounts = new HashSet<Account>();
        }

        #region Navigation Properties

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Account> Accounts { get; set; }
        #endregion

    }
}
