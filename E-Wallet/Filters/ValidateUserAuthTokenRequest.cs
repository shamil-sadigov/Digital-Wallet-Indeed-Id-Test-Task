using EWallet.Core.Models.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Filters
{
    public sealed class ValidateUserAuthTokenRequest: ValidationAttributeBase
    {
        private readonly IValidator<UserAuthTokenRequest> userValidator;

        public ValidateUserAuthTokenRequest(IValidator<UserAuthTokenRequest> validator)
            => this.userValidator = validator;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = RetrieveArgument<UserAuthTokenRequest>(context);

            var result = userValidator.Validate(request);

            if (!result.IsValid)
            {
                ReturnBadRequest(context, error: string.Concat(result.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            result = await userValidator.ValidateAsync(request, ruleSet: "EmailIsRegistered");

            if (!result.IsValid)
            {
                ReturnBadRequest(context, error: string.Concat(result.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            await next();
        }
    }
}
