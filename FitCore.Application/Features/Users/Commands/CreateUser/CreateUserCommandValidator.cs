using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Förnamn är obligatoriskt.")
                .MaximumLength(50).WithMessage("Förnamnet får max vara 50 tecken.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Efternamn är obligatoriskt.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Du måste ange en giltig e-postadress.");

            RuleFor(x => x.CurrentWeight)
                .GreaterThan(0).WithMessage("Vikten måste vara positiv.")
                .LessThan(300).WithMessage("Är du säker på att du väger över 300kg?");



        }
    }
}
