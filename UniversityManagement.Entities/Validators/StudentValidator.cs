using FluentValidation;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Validators
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Address is required");
            RuleFor(x=>x.StudentName).NotNull().NotEmpty().WithMessage("Student name is required");
        }
    }
}
