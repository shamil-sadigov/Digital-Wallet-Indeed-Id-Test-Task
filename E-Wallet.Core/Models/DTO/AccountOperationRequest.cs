using EWallet.Core.Models.Domain;
using MediatR;

namespace EWallet.Core.Models.DTO
{
    public class AccountOperationRequest : IRequest<(bool succeeded, string errorMessage)>
    {
        public string AccountId { get; set; }
        public decimal Amount { get; set; }
        public OperationDirection Direction { get; set; }

        private AccountOperationRequest(string accountId, decimal amount, OperationDirection direction)
        {
            AccountId = accountId;
            Amount = amount;
            Direction = direction;
        }


        public static AccountOperationRequest InOperation(AccountOperation operation)
            => new AccountOperationRequest(operation.AccountId, operation.Amount, OperationDirection.In);


        public static AccountOperationRequest OutOperation(AccountOperation operation)
            => new AccountOperationRequest(operation.AccountId, operation.Amount, OperationDirection.Out);

    }
}
