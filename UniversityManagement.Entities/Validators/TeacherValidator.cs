using FluentValidation;
using UniversityManagement.Entities.Models;
namespace UniversityManagement.Entities.Validators
{
    public class TeacherValidator: AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(x => x.TeacherName).NotNull().NotEmpty().WithMessage("Teacher Name is Required");
            RuleFor(x=>x.Description).NotNull().NotEmpty().WithMessage("Description Name is Required"); 
            RuleFor(x=>x.Subjects).NotNull().NotEmpty().WithMessage("Subject Name is Required");
        }
    }
}
