using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Filters
{
    public sealed class ValidateCurrencyName : ValidationAttributeBase
    {
        private readonly ICurrencyHelper currencyHelper;
        private readonly IValidator<AccountCreationRequest> validator;

        public ValidateCurrencyName(ICurrencyHelper currencyHelper,
                                    IValidator<AccountCreationRequest> validator)
        {
            this.currencyHelper = currencyHelper;
            this.validator = validator;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = RetrieveArgument<AccountCreationRequest>(context);

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                ReturnBadRequest(context, error: string.Concat(result.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            if (!await currencyHelper.IsValidCurrencyNameAsync(request.CurrencyIsoName.Trim()))
            {
                ReturnBadRequest(context, "Currency name is not valid");
                return;
            }

            await next();
        }
    }
}
