using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using System;

namespace EWallet.Application.Services
{
    public class AccountBuilder : IAccountBuilder
    {
        private readonly Account account;
        public AccountBuilder(Account account)
            => this.account = account;
        

        public IAccountBuilder WithCurrency(Currency currency)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));

            account.Currency = currency;
            return this;
        }

        public IAccountBuilder WithBalance(decimal balance)
        {
            if (balance < 0)
                throw new ArgumentOutOfRangeException(nameof(balance));

            account.Balance = balance;
            return this;
        }

        public IAccountBuilder OnWallet(string walletId)
        {
            if (string.IsNullOrEmpty(walletId))
                throw new ArgumentException(nameof(walletId));

            account.WalletId = walletId;
            return this;
        }

        public Account Build()
            => account;
    }
}
