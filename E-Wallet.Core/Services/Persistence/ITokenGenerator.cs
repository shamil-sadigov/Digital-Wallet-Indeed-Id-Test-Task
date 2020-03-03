namespace EWallet.Core.Services.Persistence
{

    /// <summary>
    /// Token generator that generates token synchronously
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITokenGenerator<T> 
    {
        string GenerateToken(T entity);
    }

}
