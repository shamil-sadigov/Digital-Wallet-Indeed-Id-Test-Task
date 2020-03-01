using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Wallet.Core.Services.Persistence
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Set { get; set; }
        Task SaveChangesAsync();
    }

}
