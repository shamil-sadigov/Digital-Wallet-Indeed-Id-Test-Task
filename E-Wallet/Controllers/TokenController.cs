using EWallet.Core.Models.DTO;
using EWallet.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EWallet.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TokenController : Controller
    {
        private readonly IMediator mediator;

        public TokenController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <remarks>
        /// <b style="color: #f14d2f;align-contentalign-content:;" >
        /// Before use this action, ensure you registered a user in endpoint /api/auth/register</b><br/> <br/> 
        /// This action takes registered user credentials and returns user authentication token
        /// <br/> <br/> <br/> 
        /// <b>What authenticaion token is used for ?</b><br/> 
        /// Well, Primarily authentication token is only for getting another token namely "PermissionToken".
        /// You cannot do anything with authentication token except for getting "PermissionToken". So ...<br/><br/> <br/> 
        /// <b style="color: #f14d2f;align-contentalign-content:;" > 
        /// To get familiar with "Permission token" please read description of endpoint => /api/token/getPermissionToken</b>
        /// <br/><br/> 
        /// </remarks>
        /// <response code="200">In case user provided valid credentials, token is returned</response>
        /// <response code="400">In cases when: Email or password invalid. Email is not registere and so on...</response>
        [HttpPost]
        [TypeFilter(typeof(ValidateUserAuthTokenRequest))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenReponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> GetUserAuthenticationToken([FromBody] UserAuthTokenRequest request)
        {
            (string errorMessage, string token) = await mediator.Send(request);

            if (token is null)
                return BadRequest(new BadRequestResponse(errorMessage));

            return Ok(new TokenReponse(token));
        }




        /// <remarks>
        /// <b style="color: #f14d2f;align-contentalign-content:;" >
        /// Before use this action, ensure you got authentication token from endpoint /api/token/getUserAuthenticationToken
        /// and added this token in Authorization header of HTTP request (Example: Authorization: Bearer your_auth_token)</b><br/> <br/> 
        /// This action takes permission names and generates token based on provided permission names which called Permission token
        /// <br/> <br/> <br/> 
        /// <b>What is Permission?</b><br/> 
        /// Well, permission allow you to act in a constrained scope.<br/> 
        /// Example 1: PermissionToken with name "account-create"
        /// will allow user only to create a new account. User won't be able to replenish or withdraw funds from account
        /// <br/> 
        /// Example 2: PermissionToken with name "account-replenish"
        /// will allow user only to replenish funds on account. User won't be able to withdraw funds from account, or create new account or whatever <br/> 
        /// User can have one permission token that allow you different scopes ["account-create", "account-withdraw"] with one token<br/> <br/> 
        /// <b>Permission name list:</b><br/> 
        /// "account-create" => allows to create new account for user<br/> 
        /// "account-replenish" => allows to replenish funds on user account<br/> 
        /// "account-withdraw" => allows to withdraw funds on user account<br/> 
        /// "accounts-transfer" => allows to transfer funds between user accounts<br/> 
        /// "wallet-state" => allow to view user accounts' state and also all operations made on user account<br/> 
        /// "all-permissions" => allow all permission listed above<br/> <br/>
        /// </remarks>
        /// <response code="200">In case user provided valid permissions name, permission token is returned</response>
        /// <response code="400">In cases user provided invalid permission names</response>
        [Authorize]
        [HttpPost]
        [TypeFilter(typeof(ValidatePermissionTokenRequest))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenReponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> GetPermissionToken([FromBody] PermissionTokenRequest request)
        {
            string token = await mediator.Send(request);
            return Ok(new TokenReponse(token));
        }
    }
}
