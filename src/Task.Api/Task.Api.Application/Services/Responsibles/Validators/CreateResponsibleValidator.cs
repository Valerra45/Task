using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Responsibles.Commadns;

namespace Tasks.Api.Application.Services.Responsibles.Validators
{
    public class CreateResponsibleValidator : AbstractValidator<CreateResponsibleCommand>
    {
        public CreateResponsibleValidator()
        {
            RuleFor(x => x.Responsible.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

            RuleFor(x => x.Responsible.LastName)
               .NotEmpty()
               .WithMessage("{PropertyName} is not assigned");

            RuleFor(x => x.Responsible.User)
               .NotEmpty()
               .WithMessage("{PropertyName} is not assigned");
        }
    }
}
