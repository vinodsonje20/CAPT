using Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class DeleteCheckTypeCommandValidator : AbstractValidator<DeleteCheckTypeCommand>
    {
        public DeleteCheckTypeCommandValidator() {
            RuleFor(x => x.CheckTypeId)
                   .NotEmpty().WithMessage("Check Type Id is required.");
        }
    }
}
