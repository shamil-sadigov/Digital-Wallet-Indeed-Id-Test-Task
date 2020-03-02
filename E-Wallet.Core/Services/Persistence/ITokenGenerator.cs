namespace EWallet.Core.Services.Persistence
{
    public interface ITokenGenerator<T> 
    {
        string GenerateToken(T entity);
    }
}
