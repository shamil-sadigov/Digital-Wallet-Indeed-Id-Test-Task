using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Application.Services
{
    public class AccountBuilderOptions : IAccountBuilderOptions
    {
        private readonly Account account;

        public AccountBuilderOptions(Account account)
            => this.account = account;
        

        public IAccountBuilderOptions WithCurrency(Currency currency)
        {
            account.Currency = currency;
            return this;
        }

        public IAccountBuilderOptions WithBalance(decimal balance)
        {
            account.Balance = balance;
            return this;
        }

        public IAccountBuilderOptions OnWallet(string walletId)
        {
            account.WalletId = walletId;
            return this;
        }
    }
}
