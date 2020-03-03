using EWallet.Core.Models.DTO;
using FluentValidation;

namespace EWallet.Application.Validators
{
    public class AccountCreateRequestValidator : AbstractValidator<AccountCreationRequest>
    {
        public AccountCreateRequestValidator()
        {
            RuleFor(model => model.CurrencyIsoName).NotEmpty()
                                             .Length(3,3);

        }
    }
}
