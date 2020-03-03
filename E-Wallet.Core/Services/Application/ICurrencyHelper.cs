using EWallet.Core.Models.Domain;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    public interface ICurrencyHelper
    {
        Task<bool> IsValidCurrencyNameAsync(string currencyIsoName);
        Task<Currency> ResolveCurrencyName(string currencyIsoName);
    }
}
