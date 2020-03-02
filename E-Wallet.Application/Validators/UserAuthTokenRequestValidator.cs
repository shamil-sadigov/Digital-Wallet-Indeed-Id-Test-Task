using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EWallet.Application.Validators
{
    public class UserAuthTokenRequestValidator : AbstractValidator<UserAuthTokenRequest>
    {
        public UserAuthTokenRequestValidator(IRepository<User> userRepo)
        {
            RuleFor(model => model.Email).NotEmpty();

            RuleFor(model => model.Email).EmailAddress();

            RuleFor(model => model.Password).NotEmpty()
                                            .MinimumLength(6);

            RuleSet("EmailIsRegistered", () =>
            {
                RuleFor(model => model.Email)
                .MustAsync(async (email, token) =>
                {
                    bool userExist = await userRepo.Set().AnyAsync(x => x.Email == email);
                    return userExist;
                })
                .WithMessage("User with thie Email not registered");
            });

            CascadeMode = CascadeMode.Continue;
        }
    }
}
