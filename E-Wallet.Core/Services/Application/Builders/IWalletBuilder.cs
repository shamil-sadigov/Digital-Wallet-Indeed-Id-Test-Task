using EWallet.Core.Models.Domain;

namespace EWallet.Core.Services.Application
{
    public interface IWalletBuilder : IBuilder<Wallet>
    {
        IWalletBuilder ForUser(string userId);
    }
}