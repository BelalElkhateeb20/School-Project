using FluentValidation;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Command.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;

        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyEditValidationRule();
            ApplyCustomValidationsRule();
        }

        public void ApplyEditValidationRule()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters")
                .NotNull().WithMessage("Name Must not be null");

            //RuleFor(x => x.Address)
            //    .NotEmpty().WithMessage("Address is required")
            //    .MaximumLength(50).WithMessage("Max length is 50")
            //    .NotNull().WithMessage("Address Must not be null");
        }

        public void ApplyCustomValidationsRule()
        {
            RuleFor(x => x.Name)
                .MustAsync(async ( model,name, cancellation) => !await _studentService.IsNameExistExludeSelfAsync(name,model.Id))
                .WithMessage("Name already exists");
        }
    }
}
