namespace EWallet.Core.Models.DTO
{
    public class TokenReponse 
    {
        public string Token { get; set; }
        public TokenReponse()
        {

        }

        public TokenReponse(string token)
        {
            Token = token;
        }
    }
}