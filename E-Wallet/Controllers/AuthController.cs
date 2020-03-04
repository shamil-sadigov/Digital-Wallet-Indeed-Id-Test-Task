using EWallet.Core.Models.DTO;
using EWallet.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EWallet.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
            => this.mediator = mediator;


        /// <remarks>
        /// This action registers new User with new digit wallet that has by default one account in RUB currency. 
        /// <br/> 
        /// Well, after this action, you had better get auhentication token from endpoint => /api/token/getUserAuthenticationToken
        /// <br/><br/> 
        /// <b style="color: #f14d2f;align-contentalign-content:;" > 
        /// Password Must have:</b> <br/> <br/> 
        /// Digit (0123456789) <br/>
        /// Lowecase character (a-z) <br/>
        /// Uppercase character (A-Z) <br/>
        /// Non-Alphanumeric character (!@#$ ....) <br/>
        /// Length >=6 <br/>
        /// </remarks>
        /// <response code="200">In case user registered successfully</response>
        /// <response code="400">In cases when: Password is invalid, Email is already registered, Properties are empty and so on...</response>
        [HttpPost]
        [TypeFilter(typeof(ValidateUserRegistration))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var result = await mediator.Send(request);

            if (result.succeeded)
                return Ok();

            return BadRequest(new BadRequestResponse(result.errorMessage));
        }
    }
}
