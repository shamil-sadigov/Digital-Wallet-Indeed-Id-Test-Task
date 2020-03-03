using EWallet.Core.Models.Domain;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    /// <summary>
    /// Service that returns User of current request
    /// </summary>
    public interface ICurrentUserService
    {
        Task<User> GetCurrentUserAsync();
    }
}
