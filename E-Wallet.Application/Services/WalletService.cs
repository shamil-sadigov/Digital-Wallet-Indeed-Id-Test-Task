using EWallet.Application.Builders;
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
    public class WalletService : IWalletService
    {
        public WalletService(IRepository<Wallet> repository)
        {
            Repository = repository;
        }

        public IRepository<Wallet> Repository { get; }

        // By Default create one account with Rub currency
        public async Task<(Wallet wallet, string errorMessage)> CreateWalletAsync(Action<IWalletBuilder> builderOptions)
        {
            var builder = new WalletBuilder();
            builderOptions(builder);
            Wallet newWallet = builder.Build();

            if (!await Repository.Set().AnyAsync(WalletExist(newWallet)))
            {
                await Repository.Set().AddAsync(newWallet);
                await Repository.SaveChangesAsync();

                return (newWallet, errorMessage: string.Empty);
            }

            return (null, "Wallet with this User already exist");
        }

        private Expression<Func<Wallet, bool>> WalletExist(Wallet account)
           => x => x.UserId == account.UserId;
    }
}
