namespace EWallet.Core.Services.Persistence
{
    public interface IRepository<T> : IRepositoryBase<T>, IObservableRepository<T>
        where T : class
    {

    }
}
