using EWallet.Core.Models;
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
    public class AccoutController : Controller
    {
        private readonly IMediator mediator;

        public AccoutController(IMediator mediator)
        {
            this.mediator = mediator;
        }



        /// <remarks>
        /// <b style="color: #f14d2f;align-contentalign-content:;" >
        /// Before use this action, ensure you got permission token named "account-create" or "all-permissions"
        /// from endpoint /api/token/getPermissionToken
        /// and added this token in Authorization header of HTTP request (Example: Authorization: Bearer your_auth_token)</b><br/> <br/> 
        /// This action takes currency code name of ISO 4217 and creates new Account for user
        /// <br/> <br/> <br/> 
        /// <b>Application supports following currencies:</b><br/> 
        /// "RUB", "USD", "JPY", "THB", "NZD", "MXN", "CZK" <br/><br/>
        /// Please, provide one currency name from the above list<br/> <br/>
        /// </remarks>
        /// <response code="200">In case user provided valid currency name, new Account with provided currency created</response>
        /// <response code="400">In case user provided invalid currency name</response>
        /// <response code="401">In case user unauthorized</response>
        /// <response code="403">In case user authorized, byt made it wrong 😏</response>
        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.AccountCreate)]
        [HttpGet]
        [TypeFilter(typeof(ValidateCurrencyName))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromQuery] AccountCreationRequest request)
        {
            var (succeeded, errorMessage) = await mediator.Send(request);

            if (succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(errorMessage));
        }




        /// <remarks>
        /// <b style="color: #f14d2f;align-contentalign-content:;" >
        /// Before use this action, ensure you got permission token named "account-replenish" or "all-permissions"
        /// from endpoint /api/token/getPermissionToken
        /// and added this token in Authorization header of HTTP request (Example: Authorization: Bearer your_auth_token)</b><br/> <br/> 
        /// This action replenish funds on specified accountId by specified amount
        /// <br/> <br/> <br/> 
        /// <b>If you don't know your AccountId:</b><br/> 
        /// You can get it from endpoint /api/account/state <br/> <br/>
        /// </remarks>
        /// <response code="200">In case user provided valid AccoutnId and amount, fund replenishment successfully completed</response>
        /// <response code="400">In case user provided invalid AccountId or amount</response>
        /// <response code="401">In case user unauthorized</response>
        /// <response code="403">In case user authorized, byt made it wrong 😏</response>
        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.AccountReplenish)]
        [HttpPost]
        [TypeFilter(typeof(ValidateAccountOperation))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> Replenish([FromBody] AccountOperation request)
        {
            var (succeeded, errorMessage) = await mediator.Send(AccountOperationRequest.InOperation(request));

            if (succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(errorMessage));
        }




        /// <remarks>
        /// <b style="color: #f14d2f;align-contentalign-content:;" >
        /// Before use this action, ensure you got permission token named "account-withdraw" or "all-permissions"
        /// from endpoint /api/token/getPermissionToken
        /// and added this token in Authorization header of HTTP request (Example: Authorization: Bearer your_auth_token)</b><br/> <br/> 
        /// This action withdraw funds from specified accountId by specified amount
        /// <br/> <br/> <br/> 
        /// <b>If you don't know your AccountId:</b><br/> 
        /// You can get it from endpoint /api/account/state <br/> <br/>
        /// </remarks>
        /// <response code="200">In case user provided valid AccoutnId, fund withdrawal successfully completed</response>
        /// <response code="400">In case user provided invalid AccountId or amount</response>
        /// <response code="401">In case user unauthorized</response>
        /// <response code="403">In case user authorized, byt made it wrong 😏</response>
        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.AccountWithdraw)]
        [HttpPost]
        [TypeFilter(typeof(ValidateAccountOperation))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> Withdraw([FromBody] AccountOperation request)
        {
            var (succeeded, errorMessage) = await mediator.Send(AccountOperationRequest.OutOperation(request));

            if (succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(errorMessage));
        }



        /// <remarks>
        /// <b style="color: #f14d2f;align-contentalign-content:;" >
        /// Before use this action, ensure you got permission token named "accounts-transfer" or "all-permissions"
        /// from endpoint /api/token/getPermissionToken
        /// and added this token in Authorization header of HTTP request (Example: Authorization: Bearer your_auth_token)</b><br/> <br/> 
        /// This action transfer funds from one account to another account
        /// <br/> <br/> <br/> 
        /// <b>If you don't know your AccountId:</b><br/> 
        /// You can get it from endpoint /api/account/state <br/> <br/>
        /// </remarks>
        /// <response code="200">In case user provided valid AccoutnId-s, fund transfer successfully completed</response>
        /// <response code="400">In case user provided invalid AccountId or amount</response>
        /// <response code="401">In case user unauthorized</response>
        /// <response code="403">In case user authorized, byt made it wrong 😏</response>
        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.TransferBetweenAccounts)]
        [HttpPost]
        [TypeFilter(typeof(ValidateAccountTransfer))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> Transfer([FromBody] AccountTransferRequest request)
        {
            var (succeeded, errorMessage) = await mediator.Send(request);

            if (succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(errorMessage));
        }



        /// <remarks>
        /// <b style="color: #f14d2f;align-contentalign-content:;" >
        /// Before use this action, ensure you got permission token named "wallet-state" or "all-permissions"
        /// from endpoint /api/token/getPermissionToken
        /// and added this token in Authorization header of HTTP request (Example: Authorization: Bearer your_auth_token)</b><br/> <br/> 
        /// This action returns all your accounts and it's balance and currency
        /// <br/> <br/> <br/> 
        /// </remarks>
        /// <response code="200">In case user provided valid currency name, new Account with provided currency created</response>
        /// <response code="400">In case user provided invalid currency name</response>
        /// <response code="401">In case user unauthorized</response>
        /// <response code="403">In case user authorized, byt made it wrong 😏</response>
        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.ViewWalletStateAndHistory)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDTO[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> State()
        {
            var response = await mediator.Send(new WalletStateRequest());

            return Ok(response);
        }



        /// <remarks>
        /// <b style="color: #f14d2f;align-contentalign-content:;" >
        /// Before use this action, ensure you got permission token named "wallet-state" or "all-permissions"
        /// from endpoint /api/token/getPermissionToken
        /// and added this token in Authorization header of HTTP request (Example: Authorization: Bearer your_auth_token)</b><br/> <br/> 
        /// This action returns all oeprations made on user accounts like withdrawal, perplenishment, transfer and so on...
        /// <br/> <br/> <br/> 
        /// </remarks>
        /// <response code="200">In case user provided valid currency name, new Account with provided currency created</response>
        /// <response code="400">In case user provided invalid currency name</response>
        /// <response code="401">In case user unauthorized</response>
        /// <response code="403">In case user authorized, byt made it wrong 😏</response>
        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.ViewWalletStateAndHistory)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationDTO[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> OpeartionHistory()
        {
            var response = await mediator.Send(new AccountOperationHistoryRequest());

            return Ok(response);
        }
    }
}
