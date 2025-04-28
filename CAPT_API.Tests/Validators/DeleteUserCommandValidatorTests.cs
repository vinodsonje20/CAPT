using Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Validators;
using FluentValidation.TestHelper;

namespace CAPT_API.Tests.Validators
{
    public class DeleteUserCommandValidatorTests
    {
        private readonly DeleteUserCommandValidator _validator;

        public DeleteUserCommandValidatorTests()
        {
            _validator = new DeleteUserCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Id_Is_Less_Than_One()
        {
            var model = new DeleteUserCommand { Id = 0 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Id_Is_Valid()
        {
            var model = new DeleteUserCommand { Id = 1 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
