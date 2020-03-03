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
        public ushort IsoNumberCode { get; set; }

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


        public Currency(ushort IsoNumberCode, string IsoAlfaCode):this()
        {
            this.IsoNumberCode = IsoNumberCode;
            this.IsoAlfaCode = IsoAlfaCode;
        }


        /// <summary>
        /// Compares ISOAlf Codes. Example: "RUB" == "Rub"
        /// </summary>
        /// <param name="isoAlfaCode"></param>
        /// <returns></returns>
        public bool Equals(string isoAlfaCode)
            => IsoAlfaCode.Equals(isoAlfaCode, StringComparison.InvariantCultureIgnoreCase);


        /// <summary>
        /// Compares ISONumberCodes. Example: 643 == 643
        /// </summary>
        /// <param name="isoAlfaCode"></param>
        /// <returns></returns>
        public bool Equals(ushort isoNumberCode)
            => IsoNumberCode.Equals(isoNumberCode);


        public ICollection<Account> Accounts { get; set; }
    }

}
