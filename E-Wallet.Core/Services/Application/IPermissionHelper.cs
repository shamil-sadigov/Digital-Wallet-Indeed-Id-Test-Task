using EWallet.Core.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    public interface IPermissionHelper
    {
        Task<bool> AreValidAsync(IEnumerable<string> permissionsName);
        Task<IEnumerable<PermissionClaim>> BuildClaimsAsync(IEnumerable<string> permissionsName);
    }
}
