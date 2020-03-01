using System.Collections;
using System.Collections.Generic;

namespace E_Wallet.Core.Models.Domain
{
    public class Account : IEntity<string>
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }

        public Account()
        {
            Operations = new HashSet<Operation>();
        }


        #region Navigation Properties

        public string WalletId { get; set; }
        public Wallet Wallet { get; set; }

        public short CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public ICollection<Operation> Operations { get; set; }

        #endregion
    }
}
