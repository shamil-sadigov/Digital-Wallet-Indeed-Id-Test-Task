using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EWallet.Application.Validators
{
    public class UserRegistrationValidator:AbstractValidator<UserRegistrationRequest>
    {
        public UserRegistrationValidator(IRepository<User> userRepo)
        {
            RuleFor(model => model.FirstName).NotEmpty()
                                             .MaximumLength(25);

            RuleFor(model => model.LastName).NotEmpty()
                                            .MaximumLength(25);

            RuleFor(model => model.Password).NotEmpty()
                                            .MinimumLength(6);

            RuleFor(model => model.Email).EmailAddress();

            RuleSet("EmailIsNotRegistered", () =>
            {
                RuleFor(model => model.Email)
                .MustAsync(async (email, token) =>
                {
                    bool userDoesntExist = !await userRepo.Set().AnyAsync(x => x.Email == email);
                    return userDoesntExist;
                })
                .WithMessage("User with thie Email already registered");
            });

            CascadeMode = CascadeMode.Continue;
        }
    }
}
