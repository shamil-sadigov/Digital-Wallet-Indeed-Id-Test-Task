using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    /// <summary>
    /// Repository interface that hold necessary methods to manipulate data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        DbSet<T> Set();
        Task SaveChangesAsync();
    }
}
