using EWallet.Core.Models.Domain;

namespace EWallet.Core.Services.Application
{
    public interface IAccountBuilder : IBuilder<Account>
    {
        IAccountBuilder WithCurrency(ushort currencyIsoCode);
        IAccountBuilder WithBalance(decimal balance);
        IAccountBuilder OnWallet(string walletId);
    }
}