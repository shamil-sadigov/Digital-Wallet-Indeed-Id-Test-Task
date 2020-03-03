using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Application.Services
{
    public class CurrencyHelper : ICurrencyHelper
    {
        private readonly IMemoryCache memoryCache;
        private readonly IRepository<Currency> currencyRepository;
        private List<Currency> currencies;
        private const string key = "currencies";

        public CurrencyHelper(IMemoryCache memoryCache,
                              IRepository<Currency> currencyRepository)
        {
            this.memoryCache = memoryCache;
            currencyRepository.OnRepositoryUpdateAsync += OnCurrencyRepositoryUpdate;
            this.currencyRepository = currencyRepository;
        }


        public async Task<bool> IsValidCurrencyNameAsync(string currencyIsoName)
        {
            await EnsureCurrencyListInitialized();

            return currencies.Any(x => x.Equals(currencyIsoName.Trim()));
        }

        public async Task<Currency> ResolveCurrencyName(string currencyIsoName)
        {
            await EnsureCurrencyListInitialized();

            return currencies.Where(currency => currency.Equals(currencyIsoName.Trim()))
                                   .FirstOrDefault();
        }



        #region Local methods

        private async Task OnCurrencyRepositoryUpdate(IRepositoryBase<Currency> currencyRepository)
        {
            currencies = await currencyRepository.Set().ToListAsync();
            memoryCache.Remove(key);
            memoryCache.Set(key, currencies, TimeSpan.FromMinutes(5));
        }

        private async Task EnsureCurrencyListInitialized()
        {
            if (currencies is null)
                currencies = await memoryCache.GetOrCreateAsync(key,
                    async entry =>
                    {
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                        return await currencyRepository.Set().ToListAsync();
                    });
        }

        #endregion
    }
}
