using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.DocumentTasks.Commands;

namespace Tasks.Api.Application.Services.DocumentTasks.Validators
{
    public class UpdateDocumentTaskValidator : AbstractValidator<UpdateDocumentTaskCommand>
    {
        public UpdateDocumentTaskValidator()
        {
            RuleFor(x => x.DocumentTask.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

            RuleFor(x => x.DocumentTask.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");

            RuleFor(x => x.DocumentTask.Priority)
                .NotEmpty()
                .WithMessage("{PropertyName} is not assigned");
        }
    }
}
