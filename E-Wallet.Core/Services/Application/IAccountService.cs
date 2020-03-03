using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Persistence;
using System;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    /// <summary>
    /// Service that allows you to work with Account class
    /// </summary>
    public interface IAccountService
    {
        public IRepository<Account> Repository { get; set; }
        Task<(Account account, string errorMessage)> CreateAccountAsync(Action<IAccountBuilder> builderOptions);
        Task<(bool succeeded, string errorMessage)> DecreaseBalanceAsync(Account account, decimal amount);
        Task<(bool succeeded, string errorMessage)> IncreaseBalanceAsync(Account account, decimal amount);
        Task<(bool succeeded, string errorMessage)> TransferAmount(Account fromAccount, Account toAccount, decimal amount);
    }
}
