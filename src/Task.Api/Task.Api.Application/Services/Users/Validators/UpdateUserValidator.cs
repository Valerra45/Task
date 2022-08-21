using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Users.Commands;

namespace Tasks.Api.Application.Services.Users.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.User.Email)
                .EmailAddress()
                .WithMessage("{PropertyName} is not email addres");

            RuleFor(x => x.User.Password)
                .MinimumLength(6)
                .WithMessage("{PropertyName} is less than the minimum length");

            RuleFor(x => x.User.NewPassword)
                .MinimumLength(6)
                .WithMessage("{PropertyName} is less than the minimum length");
        }
    }
}
