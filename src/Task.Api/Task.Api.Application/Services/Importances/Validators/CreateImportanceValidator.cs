using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Importances.Commands;

namespace Tasks.Api.Application.Services.Importances.Validators
{
    public class CreateImportanceValidator : AbstractValidator<CreateImportanceCommand>
    {
        public CreateImportanceValidator()
        {
            RuleFor(x => x.Importance.Name)
             .NotEmpty()
             .WithMessage("{PropertyName} is not assigned");
        }
    }
}
