namespace EWallet.Core.Models.DTO
{
    public class AccountOperation
    {
        /// <summary>
        /// AccountId should be valid
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Amount by which Account funds must be replenisehd. Should not be less than 0
        /// </summary>
        public decimal Amount { get; set; }
    }
}
