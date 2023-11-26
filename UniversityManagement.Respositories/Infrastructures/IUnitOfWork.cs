using UniversityManagement.Entities.Data;
using UniversityManagement.Respositories.IRespositories;

namespace UniversityManagement.Respositories.Infrastructures
{
    public interface IUnitOfWork : IDisposable

    {
        public IStudentRepository studentRepository { get; }
        public ISubjectRepository subjectRepository { get; }
        public ITeacherRepository teacherRepository { get; }
        public IDepartmentRepository departmentRepository { get; }
        public IClassRepository classRepository { get; }
        public IUserRepository userRepository { get; }
        public ApplicationDbContext ApplicationDbContext { get; }
        int Savechanges();
    }
}
