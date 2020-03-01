using System;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    public interface IObservableRepository<T> where T : class
    {
        event Func<IRepository<T>, Task> OnRepositoryUpdateAsync;
    }
}
