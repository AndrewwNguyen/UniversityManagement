using FluentValidation;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Validators
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(x => x.SubjectName).NotNull().NotEmpty().WithMessage("Subject Name is Required");
        }
    }
}
