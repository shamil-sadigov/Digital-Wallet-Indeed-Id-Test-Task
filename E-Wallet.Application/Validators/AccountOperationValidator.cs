using EWallet.Core.Models.DTO;
using FluentValidation;

namespace EWallet.Application.Validators
{
    public class AccountOperationValidator : AbstractValidator<AccountOperation>
    {
        public AccountOperationValidator()
        {
            RuleFor(model => model.AccountId).NotEmpty();

            RuleFor(model => model.Amount).GreaterThan(0);
        }
    }
}
