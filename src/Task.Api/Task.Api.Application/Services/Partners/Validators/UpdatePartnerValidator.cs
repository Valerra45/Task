using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Partners.Commands;

namespace Tasks.Api.Application.Services.Partners.Validators
{
    public class UpdatePartnerValidator : AbstractValidator<UpdatePartnerCommand>
    {
        public UpdatePartnerValidator()
        {
            RuleFor(x => x.Partner.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

        }
    }
}
