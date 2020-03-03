using System;
using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    /// <summary>
    /// Repository that can be observed by Observables.
    /// This is light implementation of Observer pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObservableRepository<T> where T : class
    {
        event Func<IRepositoryBase<T>, Task> OnRepositoryUpdateAsync;
    }
}
