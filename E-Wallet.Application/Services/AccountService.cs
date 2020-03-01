using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EWallet.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> repository;

        public AccountService(IRepository<Account> repository)
        {
            this.repository = repository;
        }


        public async Task<(Account account, string errorMessage)> CreateAccount(Action<IAccountBuilderOptions> builderOptions)
        {
            var newAccount = new Account();
            builderOptions(new AccountBuilderOptions(newAccount));

            if (string.IsNullOrEmpty(newAccount.WalletId))
                throw new Exception("WalletId is not set during IAccounBuilderOptions initiazliation");

            if (!await repository.Set().AnyAsync(AccountExist(newAccount)))
            {
                await repository.Set().AddAsync(newAccount);
                await repository.SaveChangesAsync();
                return (newAccount, errorMessage: string.Empty);
            }

            return (account: null, "Account already exists!");
        }



        public async Task IncreaseBalance(Account account, decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount parameter is less thatn zero");

            account.Balance += amount;
            repository.Set().Update(account);
            await repository.SaveChangesAsync();
        }


        public async Task<(bool succeeded, string errorMessage)> DecreaseBalance(Account account, decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount parameter is less than zero");

            if (account.Balance >= amount)
            {
                account.Balance -= amount;
                repository.Set().Update(account);
                await repository.SaveChangesAsync();

                return (true, errorMessage: string.Empty);
            }

            return (false, errorMessage: "Insufficient funds");
        }




        private Expression<Func<Account, bool>> AccountExist(Account account)
            => x => x.WalletId == account.WalletId
                 && x.Currency == account.Currency;

    }
}
