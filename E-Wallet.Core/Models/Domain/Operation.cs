using System;

namespace EWallet.Core.Models.Domain
{
    /// <summary>
    /// Represent operations that done on account
    /// Examples: Account funds withdrawal, Account funds replenishment
    /// </summary>
    public class Operation : IEntity<string>
    {
        public string Id { get; set; }
        public OperationDirection Direction { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        /// <summary>
        /// ctor for EF 
        /// </summary>
        public Operation()
        {

        }

        public Operation(string accountId, decimal amount, OperationDirection direction)
        {
            AccountId = accountId;
            Amount = amount;
            Direction = direction;
            Date = DateTime.UtcNow;
        }


        #region Navigation Properties

        public string AccountId { get; set; }
        public Account Account { get; set; }


        #endregion
    }
}
