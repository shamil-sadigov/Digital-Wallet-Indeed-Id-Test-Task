using EWallet.Core.Models.DTO;
using FluentValidation;

namespace EWallet.Application.Validators
{
    public class AccountTransferValidator : AbstractValidator<AccountTransferRequest>
    {
        public AccountTransferValidator()
        {
            RuleFor(model => model.FromAccountId).NotEmpty();
            RuleFor(model => model.ToAccountId).NotEmpty();

            RuleFor(model => model.Amount).GreaterThan(0);
        }
    }
}
