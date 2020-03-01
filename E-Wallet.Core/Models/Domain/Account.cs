namespace E_Wallet.Core.Models.Domain
{
    public class Account
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }


        #region Navigation Properties

        public string WalletId { get; set; }
        public Wallet Wallet { get; set; }

        public short CurrencyId { get; set; }
        public Currency Currency { get; set; }

        #endregion
    }







}
