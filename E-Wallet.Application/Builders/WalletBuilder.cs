using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Application.Builders
{
    public class WalletBuilder : IWalletBuilder
    {
        private readonly Wallet wallet;

        public WalletBuilder(Wallet wallet)
            => wallet = new Wallet();
        

        public IWalletBuilder ForUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException(nameof(userId));

            wallet.UserId = userId;
            return this;
        }

        public Wallet Build()
            => wallet;
    }
}
