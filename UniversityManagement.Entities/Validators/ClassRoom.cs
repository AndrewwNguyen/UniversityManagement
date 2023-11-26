using FluentValidation;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Entities.Validators
{
    public class ClassRoom : AbstractValidator<Department>
    {
        public ClassRoom()
        {

        }
    }
}
