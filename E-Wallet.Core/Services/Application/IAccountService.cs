using EWallet.Core.Models.Domain;
using System;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    public interface IAccountService
    {
        Task<(Account account, string errorMessage)> CreateAccountAsync(Action<IAccountBuilder> builderOptions);
        Task<(bool succeeded, string errorMessage)> DecreaseBalanceAsync(Account account, decimal amount);
        Task<(bool succeeded, string errorMessage)> IncreaseBalanceAsync(Account account, decimal amount);
        Task<(bool succeeded, string errorMessage)> TransferAmount(Account fromAccount, Account toAccount, decimal amount);

    }
}
