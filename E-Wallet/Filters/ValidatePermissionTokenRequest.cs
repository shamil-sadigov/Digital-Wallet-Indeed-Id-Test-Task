using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Filters
{
    public sealed class ValidatePermissionTokenRequest : ValidationAttributeBase
    {
        private readonly IPermissionHelper permissionHelper;

        public ValidatePermissionTokenRequest(IPermissionHelper permissionHelper)
            => this.permissionHelper = permissionHelper;
        

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = RetrieveArgument<PermissionTokenRequest>(context);

            if(!await permissionHelper.AreValidAsync(request.PermissionNames.Distinct()))
            {
                ReturnBadRequest(context, "Permission names are not valid");
                return;
            }

            await next();
        }
    }
}
