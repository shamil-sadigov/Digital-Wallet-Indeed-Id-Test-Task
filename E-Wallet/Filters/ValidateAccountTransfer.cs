using EWallet.Core.Models.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Filters
{
    public sealed class ValidateAccountTransfer : ValidationAttributeBase
    {
        private readonly IValidator<AccountTransferRequest> validator;

        public ValidateAccountTransfer(IValidator<AccountTransferRequest> validator)
        {
            this.validator = validator;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = RetrieveArgument<AccountOperationRequest>(context);

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                ReturnBadRequest(context, error: string.Concat(result.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            await next();
        }
    }



}
