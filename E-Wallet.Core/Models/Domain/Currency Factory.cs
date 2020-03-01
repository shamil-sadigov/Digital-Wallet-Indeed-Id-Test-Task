namespace E_Wallet.Core.Models.Domain
{
    public partial class Currency
    {
        public static class Factory
        {
            public static Currency RUB
                => new Currency(643, "RUB");

            public static Currency USD
                => new Currency(840, "USD");

            public static Currency JPY
                => new Currency(392, "JPY");

            public static Currency THB
                => new Currency(764, "THB");

            public static Currency NZD
                => new Currency(554, "NZD");

            public static Currency MXN
               => new Currency(484, "MXN");

            public static Currency CZK
              => new Currency(203, "CZK");
        }
    }
}
