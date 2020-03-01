using System;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    public interface IObservableRepository<T> where T : class
    {
        event Func<IRepositoryBase<T>, Task> OnRepositoryUpdateAsync;
    }
}
