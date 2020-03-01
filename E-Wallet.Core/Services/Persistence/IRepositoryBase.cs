using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    public interface IRepositoryBase<T> where T : class
    {
        DbSet<T> Set();
        Task SaveChangesAsync();
    }
}
