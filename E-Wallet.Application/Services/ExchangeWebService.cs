using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static EWallet.Application.Services.ExchangeWebService.ExchangeRoot;

namespace EWallet.Application.Services
{
    public partial class ExchangeWebService
    {
        private readonly HttpClient httpClient;
        private readonly string requestPath = "latest?base=";
        public ExchangeWebService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            if (httpClient.BaseAddress is null)
                throw new Exception("Base address is not set in httpClient");
        }



        public async Task<Rate> GetExchangeRatesAsync(string baseCurrency)
        {
            if (string.IsNullOrEmpty(baseCurrency) || baseCurrency.Length > 3)
                throw new ArgumentException("Base currency is not valid");

            var httpResponse = await httpClient.GetAsync(requestPath + baseCurrency.ToUpper());

            var root = JsonSerializer.Deserialize<ExchangeRoot>(await httpResponse.Content.ReadAsStringAsync(),
                                                                 new JsonSerializerOptions()
                                                                 {
                                                                     PropertyNameCaseInsensitive = true,
                                                                 });

            if (root.Rates is null)
                throw new JsonException("Unable to deserialize ExchangeRoot");

            return root.Rates;
        }
    }
}
