using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace E_Wallet.Core.Models.Domain
{

    public interface IEntity<T>
    {
        T Id { get; set; }
       
    }




    public class User:IdentityUser<string>, IEntity<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Wallet Wallet { get; set; }
    }







}
