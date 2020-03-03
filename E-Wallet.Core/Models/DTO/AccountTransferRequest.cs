using MediatR;

namespace EWallet.Core.Models.DTO
{
    public class AccountTransferRequest : IRequest<(bool succeeded, string errorMessage)>
    {
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
