using Microsoft.EntityFrameworkCore;

namespace EWallet.Core.Services.Persistence
{
    /// <summary>
    /// Light implementation of Repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IRepositoryBase<T>, IObservableRepository<T>
        where T : class
    {
        DbContext Context { get; }
    }
}
