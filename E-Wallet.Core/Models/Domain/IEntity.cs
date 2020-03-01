namespace EWallet.Core.Models.Domain
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

}
