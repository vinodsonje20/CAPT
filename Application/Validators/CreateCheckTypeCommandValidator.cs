using Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Validators
{
    public class CreateCheckTypeCommandValidator : AbstractValidator<CreateCheckTypeCommand>
    {
        public CreateCheckTypeCommandValidator()
        {
            RuleFor(x => x.CheckTypeName)
                .NotEmpty().WithMessage("Check Type Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}
