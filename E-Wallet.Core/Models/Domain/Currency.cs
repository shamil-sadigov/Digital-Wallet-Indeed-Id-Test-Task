using System;
using System.Collections;
using System.Collections.Generic;

namespace EWallet.Core.Models.Domain
{
    public partial class Currency : IEquatable<string>, IEquatable<ushort>
    {

        /// <summary>
        /// Example: 683, 424
        /// </summary>
        public ushort IsoNumberCode { get; set; } // natural Primary key

        /// <summary>
        /// Example: "RUB" "USD"
        /// </summary>
        public string IsoAlfaCode { get; set; }


        /// <summary>
        /// Ctor for EF Core
        /// </summary>
        public Currency()
        {
            Accounts = new HashSet<Account>();
        }


        private Currency(ushort IsoNumberCode, string IsoAlfaCode):this()
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



        public ICollection<Account> Accounts { get; set; }
    }

}
