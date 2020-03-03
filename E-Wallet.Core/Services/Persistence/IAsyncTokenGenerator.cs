using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    public interface IAsyncTokenGenerator<T>
    {
        Task<string> GenerateTokenAsync(T entity);
    }

}
