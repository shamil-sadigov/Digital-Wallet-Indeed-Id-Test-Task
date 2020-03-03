namespace EWallet.Core.Models.DTO
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public string CurrencyIsoName { get; set; }
        public decimal Balance { get; set; }
    }
}
