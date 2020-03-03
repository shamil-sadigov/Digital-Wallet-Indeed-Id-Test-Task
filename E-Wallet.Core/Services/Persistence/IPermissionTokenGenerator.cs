using System.Collections.Generic;

namespace EWallet.Core.Services.Persistence
{
    /// <summary>
    /// Token generator that generates permission tokenes
    /// To get familiar with permission tokens, go to Permission and PermissionAbstractFactory classes
    /// </summary>
    public interface IPermissionTokenGenerator : IAsyncTokenGenerator<IEnumerable<string>>
    {

    }
}
