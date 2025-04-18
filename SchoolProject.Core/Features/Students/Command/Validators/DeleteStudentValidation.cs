using FluentValidation;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Command.Validators
{
    public class DeleteStudentValidation:AbstractValidator<DeleteStudentCommand>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentValidation(IStudentService studentService)
        {
            ApplyValidationsRule();
            _studentService = studentService;

        }

        public void ApplyValidationsRule()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .NotNull().WithMessage("Id Must not be null");
        }
    }
}
