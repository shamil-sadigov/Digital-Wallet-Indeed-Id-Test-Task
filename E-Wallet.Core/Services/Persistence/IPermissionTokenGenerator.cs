using System.Collections.Generic;

namespace EWallet.Core.Services.Persistence
{
    public interface IPermissionTokenGenerator : IAsyncTokenGenerator<IEnumerable<string>>
    {

    }
}
