namespace EWallet.Core.Services.Persistence
{
    public interface IRepositoryBase<T> : IRepository<T>, IObservableRepository<T>
        where T : class
    {

    }
}
