using EWallet.Core.Models.Domain;
using System;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    public interface IWalletService
    {
        Task<(Wallet wallet, string errorMessage)> CreateWalletAsync(Action<IWalletBuilder> builderOptions);
    }
}