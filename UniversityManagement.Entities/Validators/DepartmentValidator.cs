using FluentValidation;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x=>x.DepartmentName).NotNull().NotEmpty().WithMessage("Department name is required");
        }
    }
}
