using EWallet.Core.Models.Domain;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Application
{
    public interface ICurrentUserService
    {
        Task<User> GetCurrentUserAsync();
    }
}
