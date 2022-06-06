using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Users.Commands;

namespace Tasks.Api.Application.Services.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.User.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

            RuleFor(x => x.User.Email)
                .EmailAddress()
                .WithMessage("{PropertyName} is not email addres");

            RuleFor(x => x.User.Role)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

            RuleFor(x => x.User.Password)
                .MinimumLength(6)
                .WithMessage("{PropertyName} is less than the minimum length");
        }
    }
}


