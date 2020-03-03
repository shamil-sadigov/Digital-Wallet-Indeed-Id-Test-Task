using EWallet.Core.Models.Domain;
using System;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    /// <summary>
    /// Service that enables you to register wallet
    /// </summary>
    public interface IWalletService
    {
        Task<(Wallet wallet, string errorMessage)> CreateWalletAsync(Action<IWalletBuilder> builderOptions);
    }
}