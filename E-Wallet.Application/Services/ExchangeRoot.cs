namespace EWallet.Application.Services
{
    public partial class ExchangeWebService
    {
        public class ExchangeRoot
        {
            public Rate Rates { get; set; }

            public class Rate
            {
                public decimal USD { get; set; }
                public decimal RUB { get; set; }
                public decimal JPY { get; set; }
                public decimal THB { get; set; }
                public decimal NZD { get; set; }
                public decimal MXN { get; set; }
                public decimal CZK { get; set; }
            }
        }

    }

}
