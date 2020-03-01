using System;

namespace E_Wallet.Core.Models.Domain
{
    public partial class Currency : IEquatable<string>, IEquatable<ushort>
    {
        public ushort IsoNumberCode { get; set; } // natural Primary key
        public string IsoAlfaCode { get; set; }

        public Currency()
        {

        }


        private Currency(ushort IsoNumberCode, string IsoAlfaCode)
        {
            this.IsoNumberCode = IsoNumberCode;
            this.IsoAlfaCode = IsoAlfaCode;
        }

    
        // Example: "RUB" == "Rub"
        public bool Equals(string isoAlfaCode)
            => IsoAlfaCode.Equals(isoAlfaCode, StringComparison.InvariantCultureIgnoreCase);
        
        // Example: 643 == 643
        public bool Equals(ushort isoNumberCode)
            => IsoNumberCode.Equals(isoNumberCode);
    }

}
