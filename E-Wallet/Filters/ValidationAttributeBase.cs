using EWallet.Core.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace EWallet.Filters
{
    public abstract class ValidationAttributeBase : Attribute, IAsyncActionFilter
    {
        public abstract Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next);

        protected void ReturnBadRequest(ActionExecutingContext context, string error)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(new BadRequestResponse(error));
        }
    }
}
