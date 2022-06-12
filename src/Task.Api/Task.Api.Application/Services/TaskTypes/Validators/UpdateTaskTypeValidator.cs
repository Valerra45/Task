using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.TaskTypes.Commands;

namespace Tasks.Api.Application.Services.TaskTypes.Validators
{
    public class UpdateTaskTypeValidator : AbstractValidator<UpdateTaskTypeCommand>
    {
        public UpdateTaskTypeValidator()
        {
            RuleFor(x => x.TaskType.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");
        }
    }
}
