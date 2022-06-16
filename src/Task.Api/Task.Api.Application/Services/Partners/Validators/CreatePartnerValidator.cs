using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Partners.Commands;

namespace Tasks.Api.Application.Services.Partners.Validators
{
    public class CreatePartnerValidator : AbstractValidator<CreatePartnerCommand>
    {
        public CreatePartnerValidator()
        {
            RuleFor(x => x.Partner.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

            RuleFor(x => x.Partner.Address)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

            RuleFor(x => x.Partner.Phone)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

        }
    }
}
