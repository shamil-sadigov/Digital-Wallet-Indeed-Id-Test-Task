using EWallet.Core.Models.Domain;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    /// <summary>
    /// Helper interface that allows you to validate and resolve, convert currency ISO codes
    /// </summary>
    public interface ICurrencyHelper
    {
        Task<bool> IsValidCurrencyNameAsync(string currencyIsoName);
        Task<Currency> ResolveCurrencyName(string currencyIsoName);
        Task<Currency> ResolveCurrencyName(ushort currencyIsoCode);
        Task<decimal> ConvertAsync(Currency from, Currency to, decimal amount);
    }
}
