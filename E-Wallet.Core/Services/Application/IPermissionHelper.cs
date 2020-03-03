using EWallet.Core.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    /// <summary>
    /// Helper interface with the help of which you can validate 
    /// permission names and build claims base on permission names
    /// </summary>
    public interface IPermissionHelper
    {
        Task<bool> AreValidAsync(IEnumerable<string> permissionsName);
        Task<IEnumerable<PermissionClaim>> BuildClaimsAsync(IEnumerable<string> permissionsName);
    }
}
