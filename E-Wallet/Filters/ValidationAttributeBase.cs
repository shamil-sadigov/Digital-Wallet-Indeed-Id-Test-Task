using EWallet.Core.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Filters
{
    public abstract class ValidationAttributeBase : Attribute, IAsyncActionFilter
    {
        public abstract Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next);

        protected static void ReturnBadRequest(ActionExecutingContext context, string error)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(new BadRequestResponse(error));
        }

        protected static T RetrieveArgument<T>(ActionExecutingContext context) where T :class
            => context.ActionArguments.FirstOrDefault(x => x.Value is T)
                      .Value as T ?? throw new ArgumentException($"No {nameof(T)} has been detected. Request is not valid");
        
    }
}
