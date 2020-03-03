using MediatR;

namespace EWallet.Core.Models.DTO
{
    public class AccountCreationRequest:IRequest<(bool succeeded, string errorMessage)>
    {
        // Example: RUB, USD
        public string CurrencyIsoName { get; set; }
    }
}
