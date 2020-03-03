using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EWallet.Core.Models.Domain
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

        public ushort CurrencyIsoNumberCode { get; set; }

        [ForeignKey("CurrencyIsoNumberCode")]
        public Currency Currency { get; set; }

        public ICollection<Operation> Operations { get; set; }

        #endregion
    }
}
