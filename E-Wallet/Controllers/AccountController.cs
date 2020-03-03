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


        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.AccountCreate)]
        [HttpGet]
        [TypeFilter(typeof(ValidateCurrencyName))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> Create([FromQuery] AccountCreationRequest request)
        {
            var result = await mediator.Send(request);

            if (result.succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(result.errorMessage));
        }



        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.AccountReplenish)]
        [HttpPost]
        [TypeFilter(typeof(ValidateAccountOperation))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> Replenish([FromBody] AccountOperation request)
        {
            var result = await mediator.Send(AccountOperationRequest.InOperation(request));

            if (result.succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(result.errorMessage));
        }




        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.AccountWithdraw)]
        [HttpPost]
        [TypeFilter(typeof(ValidateAccountOperation))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> Withdraw([FromBody] AccountOperation request)
        {
            var result = await mediator.Send(AccountOperationRequest.OutOperation(request));

            if (result.succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(result.errorMessage));
        }




        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.TransferBetweenAccounts)]
        [HttpPost]
        [TypeFilter(typeof(ValidateAccountTransfer))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> Transfer([FromBody] AccountTransferRequest request)
        {
            var result = await mediator.Send(request);

            if (result.succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(result.errorMessage));
        }




        [Authorize(Policy = Core.Models.AuthorizationPolicy.Names.ViewWalletStateAndHistory)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDTO[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> State()
        {
            var response = await mediator.Send(new WalletStateRequest());

            return Ok(response);
        }




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
