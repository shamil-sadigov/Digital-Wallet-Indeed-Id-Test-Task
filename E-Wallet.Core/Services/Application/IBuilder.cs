namespace EWallet.Core.Services.Application
{
    public interface IBuilder<out T>
    {
        T Build();
    }

}
