using FluentValidation;
using SchoolProject.Core.Features.Students.Command.Models;

namespace SchoolProject.Core.Features.Students.Command.Validators
{
    public class AddStudentValidation:AbstractValidator<AddStudentCommand>
    {
        public AddStudentValidation()
        {
            ApplyValidationsRule();
            ApplyCustomValidationsRule();
        }
        public void ApplyValidationsRule()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters")
                .NotNull().WithMessage("Name Must not be null");

            RuleFor(x=>x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(50).WithMessage("Max length is 50")
                .NotNull().WithMessage("Address Must not be null");
        }
        public void ApplyCustomValidationsRule()
        {

        }
    }
}
