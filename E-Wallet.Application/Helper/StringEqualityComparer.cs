using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EWallet.Application.Helper
{
    public class StringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
            => x.Trim().Equals(y.Trim(), StringComparison.InvariantCultureIgnoreCase);
        

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.GetHashCode();
        }
    }
}
