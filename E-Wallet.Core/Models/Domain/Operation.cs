using System;

namespace E_Wallet.Core.Models.Domain
{
    public class Operation : IEntity<string>
    {
        public string Id { get; set; }
        public OpeartionDirection Direction { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        #region Navigation Properties

        public string AccountId { get; set; }
        public Account Account { get; set; }

        #endregion
    }


    public enum OpeartionDirection
    {
        In, Out
    }
}
