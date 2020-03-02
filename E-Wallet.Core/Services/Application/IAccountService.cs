using EWallet.Core.Models.Domain;
using System;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    public interface IAccountService
    {
        Task<(Account account, string errorMessage)> CreateAccount(Action<IAccountBuilder> builderOptions);
        Task<(bool succeeded, string errorMessage)> DecreaseBalance(Account account, decimal amount);
        Task IncreaseBalance(Account account, decimal amount);
    }


    public interface IWalletService
    {
        Task<Wallet> CreateWallet(Action<IWalletBuilder> builderOptions);
    }


    public interface ICurrentUserService
    {
        Task<User> CurrentUser { get; }
    }
}
