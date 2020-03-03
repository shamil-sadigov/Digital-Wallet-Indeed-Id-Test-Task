using System.Threading.Tasks;

namespace EWallet.Core.Services.Persistence
{
    /// <summary>
    /// Token generator that generates token asynchronously
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncTokenGenerator<T>
    {
        Task<string> GenerateTokenAsync(T entity);
    }
}
