using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.Core.Services.Persistence
{
    public interface IObservableRepository<T> where T : class
    {
        event Func<IRepository<T>, Task> OnRepositoryUpdateAsync;
    }
}
