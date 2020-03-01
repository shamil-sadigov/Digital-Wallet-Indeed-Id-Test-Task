using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Set { get; set; }
        Task SaveChangesAsync();
    }

}
