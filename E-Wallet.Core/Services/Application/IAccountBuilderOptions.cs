using EWallet.Core.Models.Domain;

namespace EWallet.Core.Services.Application
{
    public interface IAccountBuilderOptions
    {
        IAccountBuilderOptions WithCurrency(Currency currency);
        IAccountBuilderOptions WithBalance(decimal balance);
        IAccountBuilderOptions OnWallet(string walletId);
    }

}
