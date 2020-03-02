using MediatR;

namespace EWallet.Core.Models.DTO
{
    public class UserAuthTokenRequest:IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}