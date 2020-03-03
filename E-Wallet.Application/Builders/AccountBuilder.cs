using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using System;

namespace EWallet.Application.Builders
{
    public class AccountBuilder : IAccountBuilder
    {
        private readonly Account account;
        public AccountBuilder()
            => account = new Account();


        public IAccountBuilder WithCurrency(ushort currencyIsoCode)
        {
            account.CurrencyIsoNumberCode = currencyIsoCode;
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
