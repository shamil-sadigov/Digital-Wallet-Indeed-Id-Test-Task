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


        [HttpPost]
        [TypeFilter(typeof(ValidateUserAuthTokenRequest))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> GetUserAuthenticationToken([FromBody] UserAuthTokenRequest request)
        {
            string token = await mediator.Send(request);
            return Ok(token);
        }


        [Authorize]
        [HttpPost]
        [TypeFilter(typeof(ValidatePermissionTokenRequest))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> GetPermissionToken([FromBody] PermissionTokenRequest request)
        {
            string token = await mediator.Send(request);
            return Ok(token);
        }
    }
}
